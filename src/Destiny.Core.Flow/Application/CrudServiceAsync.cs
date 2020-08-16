using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.Flow.Application
{
    //public class CrudServiceAsync<TEntity, TPrimaryKey> : ICrudServiceAsync<TEntity, TPrimaryKey>
    //        where TEntity : IEntity<TPrimaryKey>, IEquatable<TPrimaryKey>
    //{
    //    private readonly IServiceProvider _serviceProvider = null;
    //    private readonly IEFCoreRepository<TEntity, TPrimaryKey> _efCoreRepository = null;

    //    public CrudServiceAsync(IServiceProvider serviceProvider)
    //    {
    //        _serviceProvider = serviceProvider;
    //        _efCoreRepository = _serviceProvider.GetService<IEFCoreRepository<TEntity, TPrimaryKey>>();
    //    }

    //    public Task<OperationResponse> DeleteAsync(TPrimaryKey primaryKey)
    //    {
           
    //    }
    //    protected virtual Task<OperationResponse> BeforeDeleteAsync(TEntity entity)
    //    {
    //        OperationResponse response = new OperationResponse();
       
    //        return Task.FromResult(response);
    //    }

    //    protected virtual Task<OperationResponse> AfterDeleteAsync(TEntity entity)
    //    {
    //        return Task.FromResult(Ok());
    //    }

    //    public IQueryable<TEntity> Query()
    //    {
    //      return  _efCoreRepository.Entities;
    //    }

    //    public IQueryable<TEntity> QueryNoTracking()
    //    {
    //        return _efCoreRepository.TrackEntities;
    //    }
    //}
}
