using AutoMapper;
using Destiny.Core.Flow;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Destiny.Core.Flow.AutoMapper
{
  public abstract  class AutoMapperModuleBase : AppModuleBase
    {

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var assemblyFinder =  services.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>();
            var assemblys = assemblyFinder.FindAll();
            var myAutoMapTypes = assemblys.SelectMany(o => o.GetTypes()).Where(t => t.IsClass && !t.IsAbstract && t.HasAttribute<AutoMappAttribute>(true)).Distinct().ToArray();
            services.AddAutoMapper(mapper => {

                this.CreateMapping<AutoMappAttribute>(myAutoMapTypes,mapper);

            },assemblys, ServiceLifetime.Singleton);
            var mapper= services.GetService<IMapper>();
            Destiny.Core.Flow.Extensions.Extensions.SetMapper(mapper); 
            return services;
        }

        private void CreateMapping<TAttribute>(Type[] sourceTypes, IMapperConfigurationExpression mapperConfigurationExpression)
     where TAttribute : AutoMappAttribute
        {
            foreach (var sourceType in sourceTypes)
            {
                var attribute = sourceType.GetCustomAttribute<TAttribute>();
                if (attribute.TargetTypes?.Count() <= 0)
                {
                    return;
                }
                foreach (var tatgetType in attribute.TargetTypes)
                {

                    if (attribute.Direciton.HasFlag(AutoMapDirection.To))
                    {
                        mapperConfigurationExpression.CreateMap(sourceType, tatgetType);
                    }

                    if (attribute.Direciton.HasFlag(AutoMapDirection.From))
                    {
                        mapperConfigurationExpression.CreateMap(tatgetType, sourceType);
                    }

                }
            }

        }
    }
}
