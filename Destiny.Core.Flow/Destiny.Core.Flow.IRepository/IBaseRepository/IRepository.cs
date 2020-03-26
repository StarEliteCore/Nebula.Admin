using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IRepository.IBaseRepository
{
    public interface IRepository<TEntity> where TEntity : class,new ()
    {
        #region Page
        /// <summary>
        /// 分页接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        IQueryable<TEntity> Page(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据查询条件获取总条数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);
        #endregion
        #region Query
        /// <summary>
        /// 获取所有对象（无条件）
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// 执行根据查询条件获取指定条件的实体集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 查询一个实体根据条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 异步等待执行获取所有实体集合
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync();
        /// <summary>
        /// 根据条件获取所有实体集合
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据lambda表达式条件获取单个实体
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
