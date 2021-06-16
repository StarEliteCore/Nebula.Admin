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
            var connection = settings.DbContexts.Values.First().ConnectionString;
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
