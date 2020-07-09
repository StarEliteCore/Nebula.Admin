using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Entity
{
    public abstract class SeedDataBaseAsync<TEntity, TKey> : ISeedDataAsync
            where TEntity : IEntity<TKey>
          where TKey : IEquatable<TKey>
    {
        private IServiceProvider _serviceProvider = null;

        public virtual int Order { get; protected set; } = 0;

       

        public SeedDataBaseAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual async Task InitializeAsync()
        {
            var entities= SetSeedData();
            await SaveDatabaseAsync(entities);
        }

        protected abstract TEntity[] SetSeedData();

        /// <summary>
        /// 异步保存到数据库中
        /// </summary>
        /// <returns></returns>
        protected abstract Task SaveDatabaseAsync(TEntity[] entities);

    
    }
}
