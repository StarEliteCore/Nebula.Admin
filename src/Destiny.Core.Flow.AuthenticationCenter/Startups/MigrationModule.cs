using Destiny.Core.Flow.Entity.Modules;
using Destiny.Core.Flow.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
    public class MigrationModule : MigrationModuleBase
    {
        protected override bool IsAddSeedData(ApplicationContext context)
        {
            return false;
        }

        protected override bool IsAutoMigration(ApplicationContext context)
        {
            return false;
        }
    }
}
