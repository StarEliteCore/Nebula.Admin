
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.API.Startups
{
    [DependsOn(
              typeof(EventBusAppModule)

       )]
    public class EntityFrameworkCoreMySqlModule : EntityFrameworkCoreModuleBase
    {



        protected override IServiceCollection UseSql(IServiceCollection services)
        {
       

            var mySqlConn = services.GetFileByConfiguration("Destiny:DbContext:MysqlConnectionString", "未找到存放MySql数据库链接的文件");

            services.AddDbContext<DefaultDbContext>(oprions =>
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
