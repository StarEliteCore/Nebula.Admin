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
    /// <summary>
    /// Aop管理
    /// </summary>
    public class AopManager : IAopManager
    {
        /// <summary>
        /// 加载所有
        /// </summary>
        /// <param name="services"></param>

        public void AutoLoadAops(IServiceCollection services)
        {
            var typeFinder = services.GetOrAddSingletonService<ITypeFinder, TypeFinder>();

            typeFinder.NotNull(nameof(typeFinder));
            var typs=  typeFinder.Find(o => o.IsClass && !o.IsAbstract && !o.IsInterface && o.IsSubclassOf(typeof(AbstractInterceptorAttribute)));
            if (typs?.Length > 0)
            {
                foreach (var type in typs)
                {
                    services.AddTransient(type);
                    services.ConfigureDynamicProxy(cof =>
                    {
                        cof.Interceptors.AddTyped(type);
                    });
                }
            }
          
        }
    }
}
