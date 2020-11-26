using Destiny.Core.Flow.AuthenticationCenter.DbContexts;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Exceptions;
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
        protected override IServiceCollection AddUnitOfWork(IServiceCollection services)
        {
            return services.AddUnitOfWork<IdentityServer4DefaultDbContext>();
        }

        protected override IServiceCollection UseSql(IServiceCollection services)
        {
            var mySqlConn = services.GetFileByConfiguration("Destiny:DbContext:MysqlConnectionString", "未找到存放Ids4数据库链接的文件");


            services.AddDbContext<IdentityServer4DefaultDbContext>(oprions =>
            {
                oprions.UseMySql(mySqlConn, assembly =>
                {
                    assembly.MigrationsAssembly("Destiny.Core.Flow.Model");


                });
            });
            return services;
        }
    }
}
