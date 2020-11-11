using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Destiny.Core.Flow
{
    public class Repository<TEntity, TPrimaryKey> : IEFCoreRepository<TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
       where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        /// <summary>
        /// </summary>
        private readonly DbSet<TEntity> _dbSet = null;

        private readonly DbContext _dbContext = null;

        private readonly ILogger _logger = null;

        private readonly IPrincipal _principal;

        public Repository(IServiceProvider serviceProvider)
        {
            UnitOfWork = (serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork);
            _dbContext = UnitOfWork.GetDbContext();
            _dbSet = _dbContext.Set<TEntity>();
            _logger = serviceProvider.GetLogger<Repository<TEntity, TPrimaryKey>>();
            _principal = serviceProvider.GetService<IPrincipal>();
        }

        #region 查询

        public virtual IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 获取 <typeparamref name="TEntity"/> 不跟踪数据更改（NoTracking）的查询数据源
        /// </summary>
        public virtual IQueryable<TEntity> Entities => _dbSet.AsNoTracking();

        /// <summary>
        /// 获取 <typeparamref name="TEntity"/> 跟踪数据更改（Tracking）的查询数据源
        /// </summary>
        public virtual IQueryable<TEntity> TrackEntities => _dbSet;

        /// <summary>
        /// 根据ID得到实体
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>返回查询后实体</returns>
        public virtual TEntity GetById(TPrimaryKey primaryKey) => _dbSet.Find(primaryKey);

        /// <summary>
        /// 异步根据ID得到实体
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>返回查询后实体</returns>
        public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey primaryKey) => await _dbSet.FindAsync(primaryKey);

        /// <summary>
        /// 根据ID得到Dto实体
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>返回查询后实体并转成Dto</returns>
        public virtual TDto GetByIdToDto<TDto>(TPrimaryKey primaryKey) where TDto : class, new() => this.GetById(primaryKey).MapTo<TDto>();

        /// <summary>
        /// 异步根据ID得到Dto实体
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public virtual async Task<TDto> GetByIdToDtoAsync<TDto>(TPrimaryKey primaryKey) where TDto : class, new() => (await this.GetByIdAsync(primaryKey)).MapTo<TDto>();

        /// <summary>
        ///查询不跟踪数据源
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>返回查询后数据源</returns>
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            predicate.NotNull(nameof(predicate));
            return this.Entities.Where(predicate);
        }

        /// <summary>
        /// 查询不跟踪数据源
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate">条件</param>
        /// <param name="selector">数据筛选表达式</param>
        /// <returns>返回查询后数据源</returns>
        public virtual IQueryable<TResult> Query<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            predicate.NotNull(nameof(predicate));
            selector.NotNull(nameof(selector));
            return this.Entities.Where(predicate).Select(selector);
        }

        /// <summary>
        ///查询跟踪数据源
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>返回查询后数据源</returns>
        public virtual IQueryable<TEntity> TrackQuery(Expression<Func<TEntity, bool>> predicate)
        {
            predicate.NotNull(nameof(predicate));
            return this.TrackEntities.Where(predicate);
        }

        #endregion 查询

        #region 添加

        /// <summary>
        /// 以异步DTO插入实体
        /// </summary>
        /// <typeparam name="TInputDto">添加DTO类型</typeparam>
        /// <param name="dto">添加DTO</param>
        /// <param name="checkFunc">添加信息合法性检查委托</param>
        /// <param name="insertFunc">由DTO到实体的转换委托</param>
        /// <returns>业务操作结果</returns>
        public virtual async Task<OperationResponse> InsertAsync<TInputDto>(TInputDto dto, Func<TInputDto, Task> checkFunc = null, Func<TInputDto, TEntity, Task<TEntity>> insertFunc = null, Func<TEntity, TInputDto> completeFunc = null) where TInputDto : IInputDto<TPrimaryKey>
        {
            dto.NotNull(nameof(dto));

            try
            {
                if (checkFunc.IsNotNull())
                {
                    await checkFunc(dto);
                }

                TEntity entity = dto.MapTo<TEntity>();

                if (!insertFunc.IsNull())
                {
                    entity = await insertFunc(dto, entity);
                }
                entity = CheckInsert(entity);
                await _dbSet.AddAsync(entity);

                if (completeFunc.IsNotNull())
                {
                    dto = completeFunc(entity);
                }

                int count = await _dbContext.SaveChangesAsync();
                return new OperationResponse(count > 0 ? "添加成功" : "操作没有引发任何变化", count > 0 ? OperationResponseType.Success : OperationResponseType.NoChanged);
            }
            catch (AppException e)
            {
                return new OperationResponse(e.Message, OperationResponseType.Error);
            }
            catch (Exception ex)
            {
                return new OperationResponse(ex.Message, OperationResponseType.Error);
            }
        }

        /// <summary>
        /// 以异步插入实体
        /// </summary>
        /// <param name="entity">要插入实体</param>
        /// <returns></returns>
        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            entity.NotNull(nameof(entity));
            entity = CheckInsert(entity);

            await _dbSet.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 以异步批量插入实体
        /// </summary>
        /// <param name="entitys">要插入实体集合</param>
        /// <returns></returns>
        public virtual async Task<int> InsertAsync(TEntity[] entitys)
        {
            entitys.NotNull(nameof(entitys));
            entitys = CheckInsert(entitys);

            await _dbSet.AddRangeAsync(entitys);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 以批量插入实体
        /// </summary>
        /// <param name="entitys">要插入实体集合</param>
        /// <returns></returns>
        public virtual int Insert(params TEntity[] entitys)
        {
            entitys.NotNull(nameof(entitys));
            entitys = CheckInsert(entitys);
            _dbSet.AddRange(entitys);
            return _dbContext.SaveChanges();
        }

        #endregion 添加

        #region 更新

        /// <summary>
        /// 以异步DTO更新实体
        /// </summary>
        /// <typeparam name="TInputDto">更新DTO类型</typeparam>
        /// <param name="dto">更新DTO</param>
        /// <param name="checkFunc">添加信息合法性检查委托</param>
        /// <param name="updateFunc">由DTO到实体的转换委托</param>
        /// <returns>业务操作结果</returns>
        public virtual async Task<OperationResponse> UpdateAsync<TInputDto>(TInputDto dto, Func<TInputDto, TEntity, Task> checkFunc = null, Func<TInputDto, TEntity, Task<TEntity>> updateFunc = null) where TInputDto : class, IInputDto<TPrimaryKey>, new()
        {
            dto.NotNull(nameof(dto));
            try
            {
                TEntity entity = await this.GetByIdAsync(dto.Id);

                if (entity.IsNull())
                {
                    return new OperationResponse($"该{dto.Id}键的数据不存在", OperationResponseType.QueryNull);
                }

                if (checkFunc.IsNotNull())
                {
                    await checkFunc(dto, entity);
                }

                entity = dto.MapTo(entity);
                if (!updateFunc.IsNull())
                {
                    entity = await updateFunc(dto, entity);
                }
                entity = CheckUpdate(entity);
                _dbSet.Update(entity);
                int count = await _dbContext.SaveChangesAsync();
                return new OperationResponse(count > 0 ? "更新成功" : "操作没有引发任何变化", count > 0 ? OperationResponseType.Success : OperationResponseType.NoChanged);
            }
            catch (AppException e)
            {
                return new OperationResponse(e.Message, OperationResponseType.Error);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="entity">要更新实体</param>
        /// <returns>返回更新受影响条数</returns>
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            entity.NotNull(nameof(entity));
            entity = CheckUpdate(entity);
            _dbSet.Update(entity);
            int count = await _dbContext.SaveChangesAsync();
            return count;
        }

        /// <summary>
        /// 同步更新
        /// </summary>
        /// <param name="entity">要更新实体</param>
        /// <returns>返回更新受影响条数</returns>
        public int Update(TEntity entity)
        {
            entity.NotNull(nameof(entity));
            entity = CheckUpdate(entity);
            _dbSet.Update(entity);
            int count = _dbContext.SaveChanges();
            return count;
        }

        /// <summary>
        /// 异步批量更新
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="updateExpression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateBatchAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression, CancellationToken cancellationToken = default)
        {
            predicate.NotNull(nameof(predicate));
            predicate.NotNull(nameof(updateExpression));
            updateExpression = CheckUpdate(updateExpression);

            return await this.TrackEntities.Where(predicate).UpdateAsync(updateExpression, cancellationToken);
        }

        #endregion 更新

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public virtual async Task<OperationResponse> DeleteAsync(TPrimaryKey primaryKey)
        {
            TEntity entity = await this.GetByIdAsync(primaryKey);

            if (entity.IsNull())
            {
                return new OperationResponse($"该{primaryKey}键的数据不存在", OperationResponseType.QueryNull);
            }
            int count = await this.DeleteAsync(entity);
            return new OperationResponse(count > 0 ? "删除成功" : "操作没有引发任何变化", count > 0 ? OperationResponseType.Success : OperationResponseType.NoChanged);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">要删除实体</param>
        /// <returns>返回删除受影响条数</returns>
        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            entity = await this.GetByIdAsync(entity.Id);

            if (entity.IsNull())
            {
                throw new AppException($"该{entity.Id}键的数据不存在");
            }

            CheckDelete(entity);
            int count = await _dbContext.SaveChangesAsync();
            return count;
        }

        public virtual int Delete(params TEntity[] entitys)
        {
            foreach (var entity in entitys)
            {
                CheckDelete(entity);
            }
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 异步删除所有符合特定条件的实体
        /// </summary>
        /// <param name="predicate">查询条件谓语表达式</param>
        /// <returns>操作影响的行数</returns>
        public virtual async Task<int> DeleteBatchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            predicate.NotNull(nameof(predicate));
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                List<MemberBinding> newMemberBindings = new List<MemberBinding>();
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), "o"); //参数

                ConstantExpression constant = Expression.Constant(true);
                var propertyName = nameof(ISoftDelete.IsDeleted);
                var propertyInfo = typeof(TEntity).GetProperty(propertyName);
                var memberAssignment = Expression.Bind(propertyInfo, constant); //绑定属性
                newMemberBindings.Add(memberAssignment);

                //创建实体
                var newEntity = Expression.New(typeof(TEntity));
                var memberInit = Expression.MemberInit(newEntity, newMemberBindings.ToArray()); //成员初始化
                Expression<Func<TEntity, TEntity>> updateExpression = Expression.Lambda<Func<TEntity, TEntity>> //生成要更新的Expression
                (
                   memberInit,
                   new ParameterExpression[] { parameterExpression }
                );

                return await TrackEntities.Where(predicate).UpdateAsync(updateExpression, cancellationToken);
            }
            return await TrackEntities.Where(predicate).DeleteAsync(cancellationToken);
        }

        #endregion 删除

        #region 其他

        /// <summary>
        /// 检查删除
        /// </summary>
        /// <param name="entitys">实体集合</param>
        /// <returns></returns>
        private void CheckDelete(IEnumerable<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
                this.CheckDelete(entity);
            }
        }

        /// <summary>
        /// 检查删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        private void CheckDelete(TEntity entity)
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                ISoftDelete softDeletabl = (ISoftDelete)entity;
                softDeletabl.IsDeleted = true;
                var entity1 = (TEntity)softDeletabl;

                this._dbContext.Update(entity1);
            }
            else
            {
                this._dbContext.Remove(entity);
            }
        }

        ///// <summary>
        ///// 检查软删除接口
        ///// </summary>
        ///// <param name="entity">要检查的实体</param>
        ///// <returns>返回检查好的实体</returns>
        //private TEntity CheckISoftDelete(TEntity entity)
        //{
        //    if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
        //    {
        //        ISoftDelete softDeletableEntity = (ISoftDelete)entity;
        //        softDeletableEntity.IsDeleted = true;
        //        var entity1 = (TEntity)softDeletableEntity;
        //        return entity1;
        //    }
        //    return entity;
        //}

        /// <summary>
        /// 检查创建
        /// </summary>
        /// <param name="entitys">实体集合</param>
        /// <returns></returns>

        private TEntity[] CheckInsert(TEntity[] entitys)
        {
            for (int i = 0; i < entitys.Length; i++)
            {
                var entity = entitys[i];
                entitys[i] = CheckInsert(entity);
            }
            return entitys;
        }

        /// <summary>
        /// 检查创建时间
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        private TEntity CheckInsert(TEntity entity)
        {
            entity = CheckICreatedTime(entity);

            var creationAudited = entity.GetType().GetInterface(/*$"ICreationAudited`1"*/typeof(ICreationAudited<>).Name);
            if (creationAudited == null)
            {
                return entity;
            }

            var typeArguments = creationAudited?.GenericTypeArguments[0];
            var fullName = typeArguments?.FullName;
            if (fullName == typeof(Guid).FullName)
            {
                entity = CheckICreationAudited<Guid>(entity);
            }

            return entity;
        }

        private TEntity CheckICreationAudited<TUserKey>(TEntity entity)
           where TUserKey : struct, IEquatable<TUserKey>
        {
            if (!entity.GetType().IsBaseOn(typeof(ICreationAudited<>)))
            {
                return entity;
            }

            ICreationAudited<TUserKey> entity1 = (ICreationAudited<TUserKey>)entity;
            entity1.CreatorUserId = _principal?.Identity.GetUesrId<TUserKey>();
            entity1.CreatedTime = DateTime.Now;
            return (TEntity)entity1;
        }

        public static TEntity CheckICreatedTime(TEntity entity)
        {
            if (!(entity is ICreatedTime))
            {
                return entity;
            }
            ICreatedTime entity1 = (ICreatedTime)entity;

            entity1.CreatedTime = DateTime.Now;
            return (TEntity)entity1;
        }

        /// <summary>
        /// 检查最后修改时间
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        private TEntity[] CheckUpdate(TEntity[] entitys)
        {
            for (int i = 0; i < entitys.Length; i++)
            {
                var entity = entitys[i];
                entitys[i] = CheckUpdate(entity);
            }
            return entitys;
        }

        /// <summary>
        /// 检查最后修改时间
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        private TEntity CheckUpdate(TEntity entity)
        {
            var creationAudited = entity.GetType().GetInterface(/*$"ICreationAudited`1"*/typeof(IModificationAudited<>).Name);
            if (creationAudited == null)
            {
                return entity;
            }

            var typeArguments = creationAudited?.GenericTypeArguments[0];
            var fullName = typeArguments?.FullName;
            if (fullName == typeof(Guid).FullName)
            {
                entity = CheckIModificationAudited<Guid>(entity);
            }

            return entity;
        }

        /// <summary>
        /// 检查最后修改时间
        /// </summary>
        /// <typeparam name="TUserKey"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity CheckIModificationAudited<TUserKey>(TEntity entity)
      where TUserKey : struct, IEquatable<TUserKey>
        {
            if (!entity.GetType().IsBaseOn(typeof(IModificationAudited<>)))
            {
                return entity;
            }

            IModificationAudited<TUserKey> entity1 = (IModificationAudited<TUserKey>)entity;
            entity1.LastModifierUserId = _principal?.Identity?.GetUesrId<TUserKey>();
            entity1.LastModifionTime = DateTime.Now;
            return (TEntity)entity1;
        }

        /// <summary>
        /// 检查最后修改时间
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        private Expression<Func<TEntity, TEntity>> CheckUpdate(Expression<Func<TEntity, TEntity>> updateExpression)
        {
            var creationAudited = typeof(TEntity).GetType().GetInterface(/*$"ICreationAudited`1"*/typeof(IModificationAudited<>).Name);
            if (creationAudited == null)
            {
                return updateExpression;
            }

            var typeArguments = creationAudited?.GenericTypeArguments[0];
            var fullName = typeArguments?.FullName;
            if (fullName == typeof(Guid).FullName)
            {
                return CheckIModificationAudited<Guid>(updateExpression);
            }

            return updateExpression;
        }

        /// <summary>
        /// 检查最后修改时间
        /// </summary>
        /// <typeparam name="TUserKey"></typeparam>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public Expression<Func<TEntity, TEntity>> CheckIModificationAudited<TUserKey>(Expression<Func<TEntity, TEntity>> updateExpression)
      where TUserKey : struct, IEquatable<TUserKey>
        {
            if (!typeof(TEntity).IsBaseOn(typeof(IModificationAudited<>)))
            {
                return updateExpression;
            }
            List<MemberBinding> newMemberBindings = new List<MemberBinding>();
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), "o"); //参数

            var memberBindings = ((MemberInitExpression)updateExpression?.Body)?.Bindings;
            var propertyInfos = typeof(IModificationAudited<TUserKey>).GetProperties();
            if (memberBindings?.Count > 0)
            {
                var propertyNames = propertyInfos.Select(o => o.Name);

                foreach (var memberBinding in memberBindings.Where(o => !propertyNames.Contains(o.Member.Name)))
                {
                    newMemberBindings.Add(memberBinding);
                }
            }
            foreach (var propertyInfo in propertyInfos)
            {
                var propertyName = propertyInfo.Name;
                ConstantExpression constant = Expression.Constant(DateTime.Now);
                if (propertyName == nameof(IModificationAudited<TUserKey>.LastModifionTime))
                {
                    var memberAssignment = Expression.Bind(propertyInfo, constant); //绑定属性
                    newMemberBindings.Add(memberAssignment);
                }
                else if (propertyName == nameof(IModificationAudited<TUserKey>.LastModifierUserId))
                {
                    constant = Expression.Constant(_principal?.Identity?.GetUesrId<TUserKey>(), typeof(TUserKey));
                    var memberAssignment = Expression.Bind(propertyInfo, constant); //绑定属性
                    newMemberBindings.Add(memberAssignment);
                }
            }

            //创建实体
            var newEntity = Expression.New(typeof(TEntity));
            var memberInit = Expression.MemberInit(newEntity, newMemberBindings.ToArray()); //成员初始化
            Expression<Func<TEntity, TEntity>> updateExpression1 = Expression.Lambda<Func<TEntity, TEntity>> //生成要更新的Expression
            (
               memberInit,
               new ParameterExpression[] { parameterExpression }
            );

            return updateExpression1;
        }

        #endregion 其他
    }
}
