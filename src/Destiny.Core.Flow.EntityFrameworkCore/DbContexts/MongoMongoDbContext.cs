using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Audit;

namespace Destiny.Core.Flow.DbContexts
{
    public class MongoMongoDbContext : IMongoMongoDbContext
    {
        private readonly IServiceProvider _serviceProvider = null;
        private readonly MongoDbContextOptions _mongoDbContextOptions;

        public MongoMongoDbContext(IServiceProvider serviceProvider, MongoDbContextOptions mongoDbContextOptions)
        {
            _serviceProvider = serviceProvider;
            _mongoDbContextOptions = mongoDbContextOptions;


        }

        public IMongoDatabase Database => GetDbContext();

        public IMongoCollection<TEntity> Collection<TEntity>()
        {
           return  Database.GetCollection<TEntity>(GetTableName<TEntity>());
        }

        private string GetTableName<TEntity>()
        {
            Type t = typeof(TEntity);
            var table = t.GetAttribute<MongoDBTableAttribute>();
            if (table == null)
                throw new AppException("Table name does not exist!");
            return table.TableName;
        }


        private IMongoDatabase GetDbContext()
        {
            var client = new MongoClient(_mongoDbContextOptions.ConnectionString);
            var database = client.GetDatabase(_mongoDbContextOptions.DbName);
            return database;
        }
    }
}
