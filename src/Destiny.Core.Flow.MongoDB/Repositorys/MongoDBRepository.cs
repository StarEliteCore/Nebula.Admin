using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.MongoDB.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.MongoDB.Repositorys
{
    public class MongoDBRepository<TEntity, Tkey> : IMongoDBRepository<TEntity, Tkey>
       where TEntity : class, IEntity<Tkey>
       where Tkey : IEquatable<Tkey>
    {
        private readonly MongoDbContextBase _mongoDbContext = null;
        private readonly IMongoCollection<TEntity> _collection = null;
        private readonly IPrincipal _principal;
        //BsonDocument
        public MongoDBRepository(IServiceProvider serviceProvider, MongoDbContextBase mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;

            _collection = _mongoDbContext.Collection<TEntity>();
            _principal = serviceProvider.GetService<IPrincipal>();
        }
        public async Task InsertAsync(TEntity entity)
        {
            entity = entity.CheckInsert<TEntity, Tkey>(_principal);
            await _collection.InsertOneAsync(entity);
        }
        public async Task InsertAsync(TEntity[] entitys)
        {
            entitys = entitys.CheckInsert<TEntity, Tkey>(_principal);
            await _collection.InsertManyAsync(entitys);
        }

 


        public virtual IMongoQueryable<TEntity> Entities => _collection.AsQueryable();



    }
}

