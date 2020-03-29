
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.EntityFrameworkCore;

namespace Destiny.Core.Flow.API.Startups
{
    public class EntityFrameworkCoreMySqlModule : EntityFrameworkCoreModuleBase
    {
        protected override IServiceCollection AddRepository(IServiceCollection services)
        {
  
            return services.AddScoped(typeof(IEFCoreRepository<,>),typeof(Repository<,>));
        }

        protected override IServiceCollection AddUnitOfWork(IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork<DefaultDbContext>>();
        }

        protected override IServiceCollection UseSql(IServiceCollection services)
        {
            var Assembly = typeof(EntityFrameworkCoreMySqlModule).GetTypeInfo().Assembly.GetName().Name;//获取程序集
            var mysqlconn = services.GetConfiguration()["Destiny:DbContext:MysqlConnectionString"];
            services.AddDbContext<DefaultDbContext>(oprions => {
                oprions.UseMySql(mysqlconn, assembly => { assembly.MigrationsAssembly("Destiny.Core.Flow.Model"); });
            });
            return services;
        }
    }
}
