using DestinyCore.EntityFrameworkCore;
using DestinyCore.Events;
using DestinyCore.Extensions;
using DestinyCore.Modules;
using DestinyCore.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EntityFrameworkCore
{
    [DependsOn(
      typeof(MediatorAppModule)

   )]
    public class EntityFrameworkCoreModule : EntityFrameworkCoreModuleBase
    {
        protected override IServiceCollection AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            var settings =  services.GetObjectOrNull<AppOptionSettings>();
            //var configuration = services.GetConfiguration();
            //services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));
            //var settings = services.GetAppSettings();
            var connection = settings.DbContexts.Values.First().ConnectionString;
            var provider = services.BuildServiceProvider();
            //if (Path.GetExtension(connection).ToLower() == ".txt") //txt文件
            //{
            //    connection = provider.GetFileText(connection, $"未找到存放MySql数据库链接的文件");
            //}
            services.AddDestinyDbContext<DestinyCoreDbContext>(x =>
            {
                x.ConnectionString = connection;//settings.DbContexts.Values.First().ConnectionString;
                x.DatabaseType = settings.DbContexts.Values.First().DatabaseType;
                x.MigrationsAssemblyName = settings.DbContexts.Values.First().MigrationsAssemblyName;
            });
            services.AddUnitOfWork<DestinyCoreDbContext>();
            return services;
        }
    }
}
