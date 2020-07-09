using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Entity
{
    public abstract class SeedDataBase<TEntity, TKey> : ISeedData
            where TEntity : IEntity<TKey>
          where TKey : IEquatable<TKey>
    {
        public IServiceProvider _serviceProvider = null;

        public virtual int Order { get; protected set; } = 0;

        public virtual bool Disable { get; protected set; } = false;



        protected SeedDataBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual void Initialize()
        {
            var entities= SetSeedData();
             SaveDatabase(entities);
        }

        protected abstract TEntity[] SetSeedData();

        /// <summary>
        /// 异步保存到数据库中
        /// </summary>
        /// <returns></returns>
        protected abstract void  SaveDatabase(TEntity[] entities);


        protected abstract Expression<Func<TEntity, bool>> Expression(TEntity entity);

    
    }
}
