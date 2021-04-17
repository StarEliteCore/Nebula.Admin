using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Ui;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Application
{
    public abstract class CrudServiceAsync<TEntity, TPrimaryKey> : ICrudServiceAsync<TEntity, TPrimaryKey>
            where TEntity : IEntity<TPrimaryKey>, IEquatable<TPrimaryKey>
    {
        private readonly IServiceProvider _serviceProvider = null;
        private readonly IRepository<TEntity, TPrimaryKey> _efCoreRepository = null;

        public CrudServiceAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _efCoreRepository = _serviceProvider.GetService<IRepository<TEntity, TPrimaryKey>>();
        }

        public Task<OperationResponse> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResponse> DeleteAsync(TPrimaryKey key)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResponse> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}