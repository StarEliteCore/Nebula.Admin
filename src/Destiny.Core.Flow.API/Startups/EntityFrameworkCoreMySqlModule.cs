
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
        protected override IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IEFCoreRepository<,>), typeof(Repository<,>));
            return services;
        }

        protected override IServiceCollection AddUnitOfWork(IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork<DefaultDbContext>>();
        }

        protected override IServiceCollection UseSql(IServiceCollection services)
        {
            var fileProvider = services.GetSingletonInstanceOrNull<IFileProvider>();

            var dbpath = services.GetConfiguration()["Destiny:DbContext:MysqlConnectionString"];
            var fileInfo = fileProvider.GetFileInfo(dbpath);
            if (!fileInfo.Exists)
            {
                throw new AppException("未找到存放数据库链接的文件");
            }


            var mySqlConn = ReadAllText(fileInfo);

            services.AddDbContext<DefaultDbContext>(oprions =>
            {
                oprions.UseMySql(mySqlConn, assembly =>
                {
                    assembly.MigrationsAssembly("Destiny.Core.Flow.Model");


                });
            });
            return services;
        }


        /// <summary>
        /// 读取全部文本
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        private string ReadAllText(IFileInfo fileInfo)
        {
            byte[] buffer;
            using var stream = fileInfo.CreateReadStream();

            buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return Encoding.Default.GetString(buffer).Trim();
        }
    }
}
