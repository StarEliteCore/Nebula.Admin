using System;
using System.Linq.Expressions;

namespace Destiny.Core.Flow.Entity
{

    public abstract class SeedDataBase<TEntity, TKey> : ISeedData
            where TEntity : IEntity<TKey>
          where TKey : IEquatable<TKey>
    {
        public IServiceProvider _serviceProvider = null;

        public virtual int Order { get; protected set; } = 0;

        /// <summary>
        /// 是否禁用
        /// </summary>
        public virtual bool Disable { get; protected set; } = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        protected SeedDataBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual void Initialize()
        {
            var entities = SetSeedData();
            SaveDatabase(entities);
        }

        protected abstract TEntity[] SetSeedData();

        /// <summary>
        /// 同步保存到数据库中
        /// </summary>
        /// <returns></returns>
        protected abstract void SaveDatabase(TEntity[] entities);


        /// <summary>
        /// 条件表达树
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract Expression<Func<TEntity, bool>> Expression(TEntity entity);


    }
}
