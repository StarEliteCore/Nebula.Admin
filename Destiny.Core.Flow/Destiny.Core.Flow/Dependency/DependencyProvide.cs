using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Destiny.Core.Flow.Dependency
{
    public class DependencyProvide : IDependencyProvide
    {
       // private IServiceCollection _services;

   

        public void BulkIntoServices(IServiceCollection services)
        {
            var typs = AppRuntimeAssembly.FindAllItems();
            Type[] dependencyTypes = typs.SelectMany(o => o.GetTypes()).Where(type => type.IsClass && !type.IsAbstract && !type.IsInterface && type.HasAttribute<DependencyAttribute>()).ToArray();
            foreach (var dependencyType in dependencyTypes)
            {
                AddToServices(services, dependencyType);
            }
        }

        /// <summary>
        /// 将服务实现类型注册到服务集合中
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="implementationType">要注册的服务实例类型</param>
        protected virtual void AddToServices(IServiceCollection services, Type implementationType)
        {

            var atrr = implementationType.GetAttribute<DependencyAttribute>();
            Type[] serviceTypes = implementationType.GetImplementedInterfaces().ToArray();

            if (serviceTypes.Length == 0)
            {
                services.TryAdd(new ServiceDescriptor(implementationType, implementationType, atrr.Lifetime));
                return;
            }

            if (atrr?.AddSelf == true)
            {
                services.TryAdd(new ServiceDescriptor(implementationType, implementationType, atrr.Lifetime));
            }

            foreach (var interfaceType in serviceTypes)
            {
                services.Add(new ServiceDescriptor(interfaceType, implementationType, atrr.Lifetime));
            }
        }
    }
}
