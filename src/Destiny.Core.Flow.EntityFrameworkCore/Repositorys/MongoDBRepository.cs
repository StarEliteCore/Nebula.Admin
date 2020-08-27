using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.DbContexts;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow
{
    public class MongoDBRepository<TEntity, Tkey> : IMongoDBRepository<TEntity, Tkey>
    {
        private readonly IMongoCollection<TEntity> _collection;
        private readonly IPrincipal _principal;
        private readonly IMongoMongoDbContext _mongoMongoDbContext = null;
        //BsonDocument
        public MongoDBRepository(IServiceProvider serviceProvider)
        {

            _mongoMongoDbContext = serviceProvider.GetService<IMongoMongoDbContext>();

             _principal = serviceProvider.GetService<IPrincipal>();
            _collection = _mongoMongoDbContext.Collection<TEntity>();
        }
        public async Task InsertAsync(TEntity entity)
        {
            entity = CheckInsert(entity);
            await _collection.InsertOneAsync(entity);
        }
        public async Task InsertAsync(TEntity[] entitys)
        {
            entitys = CheckInsert(entitys);
            await _collection.InsertManyAsync(entitys);
        }

        private TEntity[] CheckInsert(TEntity[] entitys)
        {

            for (int i = 0; i < entitys.Length; i++)
            {
                var entity = entitys[i];
                entitys[i] = CheckInsert(entity);
            }
            return entitys;
        }


        /// <summary>
        /// 检查创建时间
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        private TEntity CheckInsert(TEntity entity)
        {

            entity = CheckICreatedTime(entity);

            var creationAudited = entity.GetType().GetInterface(/*$"ICreationAudited`1"*/typeof(ICreationAudited<>).Name);
            if (creationAudited == null)
            {
                return entity;
            }

            var typeArguments = creationAudited?.GenericTypeArguments[0];
            var fullName = typeArguments?.FullName;
            if (fullName == typeof(Guid).FullName)
            {
                entity = CheckICreationAudited<Guid>(entity);

            }

            return entity;

        }

        private TEntity CheckICreationAudited<TUserKey>(TEntity entity)
           where TUserKey : struct, IEquatable<TUserKey>
        {
            if (!entity.GetType().IsBaseOn(typeof(ICreationAudited<>)))
            {
                return entity;
            }

            ICreationAudited<TUserKey> entity1 = (ICreationAudited<TUserKey>)entity;
            entity1.CreatorUserId = _principal?.Identity.GetUesrId<TUserKey>();
            entity1.CreatedTime = DateTime.Now;
            return (TEntity)entity1;
        }

        public static TEntity CheckICreatedTime(TEntity entity)
        {
            if (!(entity is ICreatedTime))
            {
                return entity;
            }
            ICreatedTime entity1 = (ICreatedTime)entity;

            entity1.CreatedTime = DateTime.Now;
            return (TEntity)entity1;
        }
        public virtual IMongoQueryable<TEntity> Entities => _collection.AsQueryable();



    }
}
