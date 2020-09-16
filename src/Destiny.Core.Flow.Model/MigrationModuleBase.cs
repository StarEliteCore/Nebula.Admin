using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Destiny.Core.Flow.Model
{
    public class MigrationModuleBase : AppModule
    {
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            var configuration = context.ServiceProvider.GetService<IConfiguration>();
            var isAutoMigration = configuration["Destiny:Migrations:IsAutoMigration"].AsTo<bool>();
            if (isAutoMigration)
            {
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

            var isAddSeedData = configuration["Destiny:Migrations:IsAddSeedData"].AsTo<bool>();
            if (isAddSeedData)
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