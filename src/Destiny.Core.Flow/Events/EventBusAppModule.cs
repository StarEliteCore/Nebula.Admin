using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Events
{
  public abstract  class EventBusAppModuleBase : AppModuleBase
    {

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var assemblys=  services.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>()?.FindAll();
            services.AddEventBusDefaults(assemblys);
            return services;
        }

    }
}
