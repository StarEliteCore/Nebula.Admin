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

        protected override IServiceCollection AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            var settings = services.GetObjectOrNull<AppOptionSettings>();
         
            var connection = settings.DbContexts.Values.First().ConnectionString;
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
