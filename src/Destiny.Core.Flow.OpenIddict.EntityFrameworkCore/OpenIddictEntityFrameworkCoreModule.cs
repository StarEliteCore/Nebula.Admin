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


    public class OpenIddictEntityFrameworkCoreModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                    .UseDbContext<OpenIddictEntityDefaultDbContext>()
                    .ReplaceDefaultEntities<OpenIddictApplication, OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, Guid>();
                });

            //var settings = context.Services.GetObjectOrNull<AppOptionSettings>();
            //var connection = settings.DbContexts.Values.First().ConnectionString;
            //var provider = context.Services.BuildServiceProvider();
            var settings = context.Services.GetObjectOrNull<AppOptionSettings>();
            var connection = settings.DbContexts.Values.First().ConnectionString;
            Console.WriteLine(connection);
            context.Services.AddDestinyDbContext<OpenIddictEntityDefaultDbContext>(x =>
            {
                x.ConnectionString = connection;//settings.DbContexts.Values.First().ConnectionString;
                x.DatabaseType = settings.DbContexts.Values.First().DatabaseType;
                x.MigrationsAssemblyName = settings.DbContexts.Values.First().MigrationsAssemblyName;
            }, 
            (_, options) =>
            {
                options.UseOpenIddict<OpenIddictApplication, OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, Guid>();
                options.UseMySql(connection, ServerVersion.AutoDetect(connection), null);
            });
            context.Services.AddUnitOfWork<OpenIddictEntityDefaultDbContext>();
        }
    }
}
