using Destiny.Core.Flow.AuthenticationCenter.DbContexts;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model;
using Destiny.Core.Flow.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
    [DependsOn(
     typeof(Destiny.Core.Flow.AuthenticationCenter.Startups.MigrationModule)
     )]
    public class EntityFrameworkCoreMySqlModule: EntityFrameworkCoreModuleBase
    {
        /// <summary>
        /// 封装起来
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected override IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IEFCoreRepository<,>), typeof(Repository<,>));
            return services;
        }

        /// <summary>
        /// 封装起来
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected override IServiceCollection AddUnitOfWork(IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork<IdentityServer4DefaultDbContext>>();
        }

        protected override IServiceCollection UseSql(IServiceCollection services)
        {
            var dbPath = services.GetConfiguration()["Destiny:DbContext:MysqlConnectionString"];
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var dbcontext = Path.Combine(basePath, dbPath);
            if (!File.Exists(dbcontext))
            {
                throw new Exception("未找到存放数据库链接的文件");
            }
            var mysqlconn = File.ReadAllText(dbcontext).Trim();
            var Assembly = typeof(EntityFrameworkCoreMySqlModule).GetTypeInfo().Assembly.GetName().Name;//获取程序集

            services.AddDbContext<IdentityServer4DefaultDbContext>(oprions =>
            {
                oprions.UseMySql(mysqlconn, assembly =>
                {
                    assembly.MigrationsAssembly("Destiny.Core.Flow.Model");


                });
            });
            return services;
        }
    }
}
