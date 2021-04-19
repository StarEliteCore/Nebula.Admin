using CSRedis;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO;

namespace Destiny.Core.Flow.Caching.CSRedis
{
    public class CSRedisModule : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var provider = context.Services.BuildServiceProvider();
            var connection = context.Services.GetConfiguration()["Destiny:Redis:ConnectionString"];
            //var connection = services.GetFileByConfiguration("SuktCore:DbContext:MongoDBConnectionString", "未找到存放MongoDB数据库链接的文件");
            if (Path.GetExtension(connection).ToLower() == ".txt") //txt文件
            {
                connection = provider.GetFileText(connection, $"未找到存放Rdis链接的文件");
            }
            //var connStr = context.Services.GetFileByConfiguration("Destiny:Redis:ConnectionString", "未找到存放Rdis链接的文件");
            var csredis = new CSRedisClient(connection);
            RedisHelper.Initialization(csredis);
            context.Services.TryAddSingleton<ICache, CSRedisCache>();
        }


    }
}
