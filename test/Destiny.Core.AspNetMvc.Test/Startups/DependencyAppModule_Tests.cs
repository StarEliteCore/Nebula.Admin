using DestinyCore.Dependency;
using DestinyCore.Events;
using DestinyCore.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.Startups
{

    [DependsOn(typeof(MediatorAppModule))]
    public class DependencyAppModule_Tests: DependencyAppModule
    {
    }
}
