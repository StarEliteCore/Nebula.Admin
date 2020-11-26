using CSRedis;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO;

namespace Destiny.Core.Flow.Caching.CSRedis
{
    public class CSRedisModule : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {


            var connStr = context.Services.GetFileByConfiguration("Destiny:Redis:ConnectionString", "未找到存放Rdis链接的文件");
            var csredis = new CSRedisClient(connStr);
            RedisHelper.Initialization(csredis);
            context.Services.TryAddSingleton(typeof(ICache<>), typeof(CSRedisCache<>));
            context.Services.TryAddSingleton(typeof(ICache<,>), typeof(CSRedisCache<,>));
            context.Services.TryAddSingleton<ICache, CSRedisCache>();
        }


    }
}
