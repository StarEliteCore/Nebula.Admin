using DestinyCore.Exceptions;
using DestinyCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using DestinyCore.MongoDB.DbContexts;
using DestinyCore.MongoDB;

namespace Destiny.Core.Flow.API.Startups
{
    public class MongoDBModelule : MongoDBModuleBase
    {


        protected override void AddDbContext(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var connection = services.GetConfiguration()["Destiny:MongoDBs:MongoDBConnectionString"];
            //var connection = services.GetFileByConfiguration("SuktCore:DbContext:MongoDBConnectionString", "未找到存放MongoDB数据库链接的文件");
            if (Path.GetExtension(connection).ToLower() == ".txt") //txt文件
            {
                connection = provider.GetFileText(connection, $"未找到存放MongoDB数据库链接的文件");
            }
            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });

        }
    }

}
