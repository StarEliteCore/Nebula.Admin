using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    [DependsOn(
          typeof(MediatorAppModule)

   )]
    public class EntityFrameworkCoreModule : EntityFrameworkCoreSqlServerModule
    {

     
    }
}
