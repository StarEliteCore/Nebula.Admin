using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Destiny.Core.Flow.Entity.Modules
{
   public abstract class MigrationModuleBase : AppModule
    {


        /// <summary>
        /// 是否自动迁移
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract bool IsAutoMigration(ApplicationContext context);

        /// <summary>
        /// 是否添加种子数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract bool IsAddSeedData(ApplicationContext context);

        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();

            if (IsAutoMigration(context)) {
                context.ServiceProvider.CreateScoped(provider =>
                {
                    var unitOfWork = provider.GetService<IUnitOfWork>();
                    var dbContext = unitOfWork.GetDbContext();
                    string[] migrations = dbContext.Database.GetPendingMigrations().ToArray();
                    if (migrations.Length > 0)
                    {
                        dbContext.Database.Migrate();
                    }
                });
            }


            if (IsAddSeedData(context))
            {
                var seedDatas = context.ServiceProvider.GetServices<ISeedData>();

                foreach (var seed in seedDatas?.OrderBy(o => o.Order).Where(o => !o.Disable))
                {
                    seed.Initialize();
                }
            }
           
        }
    }
}
