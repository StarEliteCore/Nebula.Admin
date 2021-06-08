using DestinyCore.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DestinyCore.EntityFrameworkCore;
using DestinyCore.Modules;
using DestinyCore.Extensions;
using DestinyCore.Options;

namespace Destiny.Core.Flow.EntityFrameworkCore
{

    public class AuthenticationCenterEntityFrameworkCoreModule : EntityFrameworkCoreModuleBase
    {

        //public override void ConfigureServices(ConfigureServicesContext context)
        //{
        //    context.Services.AddDestinyDbContext<IdentityServer4DefaultDbContext>();
        //    context.Services.AddUnitOfWork<IdentityServer4DefaultDbContext>();
        //    context.Services.AddRepository();
        //}
        protected override IServiceCollection AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            var settings = services.GetObjectOrNull<AppOptionSettings>();
            //var configuration = services.GetConfiguration();
            //services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));
            //var settings = services.GetAppSettings();
            var connection = settings.DbContexts.Values.First().ConnectionString;
            var provider = services.BuildServiceProvider();
            //if (Path.GetExtension(connection).ToLower() == ".txt") //txt文件
            //{
            //    connection = provider.GetFileText(connection, $"未找到存放MySql数据库链接的文件");
            //}
            services.AddDestinyDbContext<IdentityServer4DefaultDbContext>(x =>
            {
                x.ConnectionString = connection;//settings.DbContexts.Values.First().ConnectionString;
                x.DatabaseType = settings.DbContexts.Values.First().DatabaseType;
                x.MigrationsAssemblyName = settings.DbContexts.Values.First().MigrationsAssemblyName;
            });
            services.AddUnitOfWork<IdentityServer4DefaultDbContext>();
            return services;
        }

    }
}
