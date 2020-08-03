using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Events
{
  public   class EventBusAppModule : AppModule
    {


        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var services = context.Services;
            var assemblys = services.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>()?.FindAll();
            services.AddMediatR(assemblys);
            services.AddEvents();
        }

     

    }
}
