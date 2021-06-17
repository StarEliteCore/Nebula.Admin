using Destiny.Core.Flow.OpenIddict.Entities;
using DestinyCore.EntityFrameworkCore;
using DestinyCore.Extensions;
using DestinyCore.Modules;
using DestinyCore.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Destiny.Core.Flow.OpenIddict.EntityFrameworkCore
{
    public class OpenIddictEntityFrameworkCoreModule : EntityFrameworkCoreModuleBase
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            base.ConfigureServices(context);
            context.Services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                    .UseDbContext<OpenIddictEntityDefaultDbContext>()
                    .ReplaceDefaultEntities<OpenIddictApplication, OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, Guid>();
                });
        }

        protected override IServiceCollection AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            var settings = services.GetObjectOrNull<AppOptionSettings>();
            var connection = "server=47.100.213.49;userid=test;pwd=pwd123456;database=Destiny.Core.Flow.OpenIddict;port=3307";// settings.DbContexts.Values.First().ConnectionString;
            var databaseType = settings.DbContexts.Values.First().DatabaseType;
            var assemblyName = settings.DbContexts.Values.First().MigrationsAssemblyName;
            services.AddDestinyDbContext<OpenIddictEntityDefaultDbContext>(x =>
            {
                x.ConnectionString = connection;
                x.DatabaseType = databaseType;
                x.MigrationsAssemblyName = assemblyName;
            },
            (_, options) =>
            {
                options.UseOpenIddict<OpenIddictApplication, OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, Guid>();
                options.UseMySql(connection, ServerVersion.AutoDetect(connection), null);
            });
            services.AddUnitOfWork<OpenIddictEntityDefaultDbContext>();
            return services;
        }
    }
}
