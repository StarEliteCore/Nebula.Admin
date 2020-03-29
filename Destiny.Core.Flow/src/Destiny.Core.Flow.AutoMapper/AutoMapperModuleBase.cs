using AutoMapper;
using Destiny.Core.Flow;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;



namespace Destiny.Core.Flow.AutoMapper
{
  public abstract  class AutoMapperModuleBase : AppModuleBase
    {

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var assemblyFinder =  services.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>();
            var assemblys = assemblyFinder.FindAll();
            services.AddAutoMapper(assemblys, ServiceLifetime.Singleton);
            var mapper= services.GetService<IMapper>();
            Destiny.Core.Flow.Extensions.Extensions.SetMapper(mapper);
            return services;
        }
    }
}
