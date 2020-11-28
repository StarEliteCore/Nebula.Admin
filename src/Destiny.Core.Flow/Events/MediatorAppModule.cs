using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Destiny.Core.Flow.Events
{
    public class MediatorAppModule : AppModule
    {


        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var services = context.Services;
            var assemblys = services.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>()?.FindAll();
            services.AddMediatR(assemblys);
            services.TryAddTransient<IMediatorHandler, InMemoryDefaultBus>();
        }



    }
}
