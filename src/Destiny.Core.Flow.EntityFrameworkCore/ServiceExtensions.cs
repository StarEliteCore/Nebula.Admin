using Destiny.Core.Flow;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Destiny.Core.Flow.Entity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddDestinyDbContext<TDbContext>(this IServiceCollection services, Action<IServiceProvider, DbContextOptionsBuilder> optionsAction = null) where TDbContext : DbContextBase
        {

            services.AddDbContext<TDbContext>((provider, builder) =>
            {

                var type = typeof(TDbContext);
                var settings = provider.GetAppSettings();
                if (settings == null)
                {

                    throw new AppException("配置不存在!!");
                }
                DestinyContextOptions contextOptions = settings.DbContexts?.Values.FirstOrDefault(o => o.DbContextType == type);

                if (contextOptions is null)
                {

                    throw new AppException($"无法找到{type.Name}数据库配置信息!!");
                }
                
                var databaseType =contextOptions.DatabaseType;

                //if (databaseType == Destiny.Core.Flow.Entity.DatabaseType.SqlServer) 
                //每个类型都要判断。可以使用一个接口，每种类型实现自己的，根据类型得到相关驱动，（策略模式？工厂模式？？）
                //{ 


                //}
                var drivenProvider = provider.GetServices<IDbContextDrivenProvider>().FirstOrDefault(o => o.DatabaseType == databaseType);


                if (drivenProvider == null)
                {
                    throw new AppException($"没有找到{databaseType}类型的驱动");
                }
                DestinyContextOptionsBuilder optionsBuilder1 = new DestinyContextOptionsBuilder();
                optionsBuilder1.MigrationsAssemblyName = contextOptions.MigrationsAssemblyName;
                builder = drivenProvider.Builder(builder, contextOptions.ConnectionString, optionsBuilder1);
                optionsAction?.Invoke(provider,builder);

            });
            return services;

        }


    }
}
