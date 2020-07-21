using CSRedis;
using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Destiny.Core.Flow.Caching.CSRedis
{
  public abstract  class CSRedisModuleBase : AppModuleBase
    {
        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
 
            var redisPath = services.GetConfiguration()["Destiny:Redis:ConnectionString"];
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var redisConn = Path.Combine(basePath, redisPath);
            if (!File.Exists(redisConn))
            {
                throw new Exception("未找到存放Rdis链接的文件");
            }
            var connStr = File.ReadAllText(redisConn).Trim();
            var csredis = new CSRedisClient(connStr);
            RedisHelper.Initialization(csredis);
            services.TryAddTransient(typeof(ICache<>), typeof(CSRedisCache<>));
            services.TryAddTransient(typeof(ICache<,>), typeof(CSRedisCache<,>));
            services.TryAddTransient<ICache, CSRedisCache>();
            return services;
        }
       
    }
}
