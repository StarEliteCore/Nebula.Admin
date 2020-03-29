using Destiny.Core.Flow.DbContexts;
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

namespace Destiny.Core.Flow.API.Startups
{
    public class EntityFrameworkCoreMySqlModule : EntityFrameworkCoreModuleBase
    {
        protected override IServiceCollection UseSql(IServiceCollection services)
        {
            var Assembly = typeof(EntityFrameworkCoreMySqlModule).GetTypeInfo().Assembly.GetName().Name;//获取程序集
            var mysqlconn = services.GetConfiguration()["Destiny:DbContext:MysqlConnectionString"];
            services.AddDbContext<DestinyContext>(oprions => {
                oprions.UseMySql(mysqlconn, assembly => { assembly.MigrationsAssembly("Destiny.Core.Flow.Model"); });
            });
            return services;
        }
    }
}
