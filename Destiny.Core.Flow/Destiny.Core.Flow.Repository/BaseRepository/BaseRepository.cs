using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Model.RepositoryBase;

namespace Destiny.Core.Flow.Repository.BaseRepository
{
    public class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
       where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        private readonly DbSet<TEntity> _dbset = null;
        private readonly DbContext _context = null;//上下文链接
        private readonly IPrincipal _principal;//
        public BaseRepository(IServiceProvider serviceProvider)
        {
            UnitOfWork = (serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork);//从容其中获取工作单元对象
            _context = UnitOfWork.GetDbContext();//获取工作单元中的上下文
            _dbset = _context.Set<TEntity>();//获取实体
            _principal = serviceProvider.GetService<IPrincipal>();
        }

        public virtual IUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 获取不跟踪数据更改（NoTracking）的查询数据源
        /// </summary>
        public virtual IQueryable<TEntity> Entities => _dbset.AsNoTracking();

        public virtual IQueryable<TEntity> TrackEntities => _dbset;
        #region Query
        /// <summary>
        /// 查询不跟踪数据源
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>返回查询后数据源</returns>
        public virtual IQueryable<TEntity> QueryAsNoTrack(Expression<Func<TEntity, bool>> predicate)
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
        public virtual IQueryable<TResult> QueryAsNoTrack<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            predicate.NotNull(nameof(predicate));//查询条件
            predicate.NotNull(nameof(selector));//需要查询的委托
            return this.Entities.Where(predicate).Select(selector);
        }
        public virtual IQueryable<TEntity> TrackQuery(Expression<Func<TEntity, bool>> predicate)
        {
            predicate.NotNull(nameof(predicate));
            return this.TrackEntities.Where(predicate);
        }
        /// <summary>
        /// 无条件获取所有数据（非实体跟踪）
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAsNoTrackAll()
        {
            return this.TrackEntities;
        }
        public virtual IQueryable<TEntity> GetTrackAll()
        {
            return this.TrackEntities;
        }
        /// <summary>
        /// 异步查询所有的数据(无条件)
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        /// <summary>
        /// 异步查询所有的数据(无条件)
        /// </summary>
        /// <typeparam name="TResult">返回的数据</typeparam>
        /// <param name="selector">需要查询的委托</param>
        /// <returns></returns>
        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            selector.NotNull(nameof(selector));
            return await _dbset.Select(selector).ToListAsync();
        }
        /// <summary>
        /// 异步查询所有的数据(有条件)
        /// </summary>
        /// <typeparam name="TResult">返回的数据实体</typeparam>
        /// <param name="predicate">条件</param>
        /// <param name="selector">需要查询的委托</param>
        /// <returns></returns>
        public  async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            predicate.NotNull(nameof(predicate));
            selector.NotNull(nameof(selector));
            return await _dbset.Where(predicate).Select(selector).ToListAsync();
        }
        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public virtual TEntity GetById(TPrimaryKey primaryKey) => _dbset.Find(primaryKey);
        /// <summary>
        /// 异步根据ID得到实体
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey primaryKey) => await _dbset.FindAsync(primaryKey);
        /// <summary>
        /// 根据条件获取一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => _dbset.FirstOrDefault(predicate);
        /// <summary>
        /// 根据条件异步获取一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await _dbset.FirstOrDefaultAsync();
        /// <summary>
        /// 根据ID得到Dto实体
        /// </summary>
        /// <typeparam name="TDto">传入的DTO实体</typeparam>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public virtual TDto GetByIdToDto<TDto>(TPrimaryKey primaryKey) where TDto : class, new() => this.GetById(primaryKey).MapTo<TDto>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public virtual async Task<TDto> GetByIdToDtoAsync<TDto>(TPrimaryKey primaryKey) where TDto : class, new() => (await this.GetByIdAsync(primaryKey)).MapTo<TDto>();
        #endregion

        #region Insert
        /// <summary>
        /// 同步新增实体集合
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual int Insert(params TEntity[] entitys)
        {
            entitys.NotNull(nameof(entitys));
            entitys = CheckInsert(entitys);
            _dbset.AddRange(entitys);
            return SaveChanges();
        }
        /// <summary>
        /// 以DTO的方式异步插入实体
        /// </summary>
        /// <typeparam name="TInputDto"></typeparam>
        /// <param name="dto"></param>
        /// <param name="checkFunc"></param>
        /// <param name="insertFunc"></param>
        /// <param name="completeFunc"></param>
        /// <returns></returns>
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
                await _dbset.AddAsync(entity);

                if (completeFunc.IsNotNull())
                {
                    dto = completeFunc(entity);
                }
                int count = await SaveChangesAsync();
                return new OperationResponse(count > 0 ? "添加成功" : "操作没有引发任何变化", count > 0 ? OperationResponseType.Success : OperationResponseType.NoChanged);
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
        /// 异步添加单条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            entity.NotNull(nameof(entity));
            entity = CheckInsert(entity);
            await _dbset.AddAsync(entity);
            return await SaveChangesAsync();
        }
        /// <summary>
        /// 异步添加集合
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual async Task<int> InsertAsync(TEntity[] entitys)
        {
            entitys.NotNull(nameof(entitys));
            entitys = CheckInsert(entitys);
            await _dbset.AddRangeAsync(entitys);
            return await SaveChangesAsync();
        }
        #endregion

        #region Delete
        public virtual int Delete(params TEntity[] entitys)
        {
            throw new NotImplementedException();
        }

        public virtual Task<OperationResponse> DeleteAsync(TPrimaryKey primaryKey)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> DeleteBatchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        #endregion



        public virtual int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<OperationResponse> IRepository<TEntity, TPrimaryKey>.UpdateAsync<TInputDto>(TInputDto dto, Func<TInputDto, TEntity, Task> checkFunc, Func<TInputDto, TEntity, Task<TEntity>> updateFunc)
        {
            throw new NotImplementedException();
        }
        #region SaveChange
        /// <summary>
        /// 
        /// </summary>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region 帮助方法
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
            entity1.LastModifierTime = DateTime.Now;
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
                if (propertyName == nameof(IModificationAudited<TUserKey>.LastModifierTime))
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
        #endregion
    }
}
