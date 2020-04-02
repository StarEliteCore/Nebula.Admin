using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.DependencyInjection;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AOP
{
    public class AopManager : IAopManager
    {
        private readonly IServiceCollection _services;

        public AopManager(IServiceCollection services)
        {
            _services = services;
        }

        public void LoadAops()
        {
            var typeFinder = _services.GetOrAddSingletonService<ITypeFinder, TypeFinder>();

            typeFinder.NotNull(nameof(typeFinder));
            var typs=  typeFinder.Find(o => o.IsClass && !o.IsAbstract && !o.IsInterface && o.IsSubclassOf(typeof(AbstractInterceptor)));
            if (typs?.Length > 0)
            {
                _services.ConfigureDynamicProxy(
                 config =>
                 {
                
                     foreach (var type in typs)
                     {
  
                         config.Interceptors.AddTyped(type);
                     }
                });
            }
        }
    }
}
