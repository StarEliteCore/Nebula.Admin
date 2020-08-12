using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow
{
    public class MongoDBRepository<TData, Tkey> : IMongoDBRepository<TData, Tkey>
    {
        private readonly IMongoCollection<TData> _collection;
        //BsonDocument
        public MongoDBRepository(IServiceProvider serviceProvider)
        {
            var configuration =  serviceProvider.GetService<IConfiguration>();
            var Dbpath = configuration["Destiny:DbContext:MongoDBConnectionString"];
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var dbcontext = Path.Combine(basePath, Dbpath);
            if (!File.Exists(dbcontext))
            {
                throw new Exception("未找到存放数据库链接的文件");
            }
            var connection = File.ReadAllText(dbcontext).Trim();
            var databasename = configuration["Destiny:DbContext:MongoDBDataBase"];
            var client = new MongoClient(connection);
            var database = client.GetDatabase(databasename);
            Type t = typeof(TData);
            var table = t.GetAttribute<MongoDBTableAttribute>();
            if (table == null)
                throw new AppException("Table name does not exist!");
            _collection = database.GetCollection<TData>(table.TableName);
        }
        public async Task InsertAsync(TData entity)
        {
            await _collection.InsertOneAsync(entity);
        }
        public async Task InsertAsync(List<TData> entitys)
        {
            await _collection.InsertManyAsync(entitys);
        }
    }
}
