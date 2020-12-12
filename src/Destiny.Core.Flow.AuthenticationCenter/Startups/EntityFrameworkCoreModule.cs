using Destiny.Core.Flow.AuthenticationCenter.DbContexts;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
    [DependsOn(
      typeof(MediatorAppModule),
      typeof(Destiny.Core.Flow.AuthenticationCenter.Startups.MigrationModule)

     )]
    public class EntityFrameworkCoreModule : EntityFrameworkCoreSqlServerModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddDestinyDbContext<IdentityServer4DefaultDbContext>();
            context.Services.AddSingleton(typeof(IDbContextDrivenProvider), typeof(SqlServerDbContextDrivenProvider));
            context.Services.AddUnitOfWork<IdentityServer4DefaultDbContext>();
            context.Services.AddScoped(typeof(IEFCoreRepository<,>), typeof(Repository<,>));
        }
    }
}
