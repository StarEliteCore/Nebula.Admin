using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Entity.Modules;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Destiny.Core.Flow.Model
{
    
    public class MigrationModule : MigrationModuleBase
    {

        protected override bool IsAddSeedData(ApplicationContext context)
        {

            var configuration = context.ServiceProvider.GetService<IConfiguration>();
            return configuration["Destiny:Migrations:IsAddSeedData"].AsTo<bool>();
        }  

        protected override bool IsAutoMigration(ApplicationContext context)
        {
            var configuration = context.ServiceProvider.GetService<IConfiguration>();
            return configuration["Destiny:Migrations:IsAutoMigration"].AsTo<bool>();
        }
    }
}