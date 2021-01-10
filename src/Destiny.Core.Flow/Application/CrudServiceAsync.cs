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

        public async Task<OperationResponse> DeleteAsync(TPrimaryKey primaryKey)
        {
            var entity = _efCoreRepository.GetById(primaryKey);
            var result = await BeforeDeleteAsync(entity);
            if (!result.Success)
            {
                return result;
            }
            result = await RemoveEntityAsync(new List<TEntity> { entity });
            if (!result.Success)
            {
                return result;
            }
            result = await AfterDeleteAsync(entity);

            return result;
        }

        protected virtual Task<OperationResponse> BeforeDeleteAsync(TEntity entity)
        {
            return Task.FromResult(OperationResponse.Ok());
        }

        protected virtual Task<OperationResponse> AfterDeleteAsync(TEntity entity)
        {
            return Task.FromResult(OperationResponse.Ok());
        }

        protected virtual IQueryable<TEntity> FindEntityQueryable => _efCoreRepository.Entities;

        protected abstract Task<OperationResponse> RemoveEntityAsync(IReadOnlyList<TEntity> entityList);
    }
}