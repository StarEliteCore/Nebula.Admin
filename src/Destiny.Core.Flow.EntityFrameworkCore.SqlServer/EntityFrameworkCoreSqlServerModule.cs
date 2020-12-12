using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.SqlServer
{
    public class EntityFrameworkCoreSqlServerModule : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddDestinyDbContext<DefaultDbContext>();
            context.Services.AddSingleton(typeof(IDbContextDrivenProvider), typeof(SqlServerDbContextDrivenProvider));
            context.Services.AddUnitOfWork<DefaultDbContext>();
            context.Services.AddScoped(typeof(IEFCoreRepository<,>), typeof(Repository<,>));
        }

       
    }
}
