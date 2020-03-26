using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.IRepository.IBaseRepository;
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
        #region MyRegion


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

        

        public virtual int Insert(params TEntity[] entitys)
        {
            throw new NotImplementedException();
        }

        public virtual Task<OperationResponse> InsertAsync<TInputDto>(TInputDto dto, Func<TInputDto, Task> checkFunc = null, Func<TInputDto, TEntity, Task<TEntity>> insertFunc = null, Func<TEntity, TInputDto> completeFunc = null) where TInputDto : IInputDto<TPrimaryKey>
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> InsertAsync(TEntity[] entitys)
        {
            throw new NotImplementedException();
        }

        

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
    }
}
