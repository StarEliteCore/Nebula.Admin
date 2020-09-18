using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.MongoDB.DbContexts;
using Destiny.Core.Flow.Ui;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.MongoDB.Repositorys
{
    public class MongoDBRepository<TEntity, Tkey> : IMongoDBRepository<TEntity, Tkey>
       where TEntity : class, IEntity<Tkey>
       where Tkey : IEquatable<Tkey>
    {
        private readonly MongoDbContextBase _mongoDbContext = null;

        private readonly IPrincipal _principal;
        public virtual IMongoCollection<TEntity> Collection { get; private set; }
        //BsonDocument
        public MongoDBRepository(IServiceProvider serviceProvider, MongoDbContextBase mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;

            Collection = _mongoDbContext.Collection<TEntity>();
            _principal = serviceProvider.GetService<IPrincipal>();

        }
        public async Task InsertAsync(TEntity entity)
        {
            entity = entity.CheckInsert<TEntity, Tkey>(_principal);
            await Collection.InsertOneAsync(entity);
        }
        public async Task InsertAsync(TEntity[] entitys)
        {
            entitys = entitys.CheckInsert<TEntity, Tkey>(_principal);
            await Collection.InsertManyAsync(entitys);

        }


        public async Task<TEntity> FindByIdAsync(Tkey key)
        {

            return await Collection.Find(CreateEntityFilter(key)).FirstOrDefaultAsync();
        }


        private IMongoQueryable<TEntity> CreateQuery()
        {
            var entities = Collection.AsQueryable();
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                entities = entities.Where(m => ((ISoftDelete)m).IsDeleted == false);

            }
            return entities;
        }


        private Expression<Func<TEntity, bool>> CreateExpression(Expression<Func<TEntity, bool>> expression)
        {
            Expression<Func<TEntity, bool>> expression1 = o => true;
            if (expression == null)
            {
                expression = o => true;
            }
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                expression1 = m => ((ISoftDelete)m).IsDeleted == false;
                expression = expression.And(expression1);
            }
            return expression;


        }
        public virtual IMongoQueryable<TEntity> Entities => CreateQuery();


        private FilterDefinition<TEntity> CreateEntityFilter(Tkey id)
        {
            var filters = new List<FilterDefinition<TEntity>>
            {
                Builders<TEntity>.Filter.Eq(e => e.Id, id)
            };
            AddGlobalFilters(filters);
            return Builders<TEntity>.Filter.And(filters);
        }
        private void AddGlobalFilters(List<FilterDefinition<TEntity>> filters)
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                filters.Add(Builders<TEntity>.Filter.Eq(e => ((ISoftDelete)e).IsDeleted, false));
            }

        }

        public async Task<OperationResponse> UpdateAsync(Tkey key, UpdateDefinition<TEntity> update)
        {

            var filters = this.CreateEntityFilter(key);


            var result = await Collection.UpdateManyAsync(filters, update);
            return result.ModifiedCount > 0 ? OperationResponse.Ok("更新成功") : OperationResponse.Error("更新失败");
        }

        public async Task<OperationResponse> DeleteAsync(Tkey key)
        {
            var filters = this.CreateEntityFilter(key);
            var result = await Collection.DeleteOneAsync(filters);
            return result.DeletedCount > 0 ? OperationResponse.Ok("删除成功") : OperationResponse.Error("删除失败");
        }
    }
}

