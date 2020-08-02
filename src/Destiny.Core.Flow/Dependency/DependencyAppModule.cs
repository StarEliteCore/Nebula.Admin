using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Dependency
{
    /// <summary>
    /// 自动注入模块
    /// </summary>
    public class DependencyAppModule: AppModuleBase
    {


        private  IServiceCollection AddAutoInjection(IServiceCollection services)
        {
            var typeFinder = services.GetOrAddSingletonService<ITypeFinder, TypeFinder>();
            var baseTypes = new Type[] { typeof(IScopedDependency), typeof(ITransientDependency), typeof(ISingletonDependency) };
            var types = typeFinder.FindAll().Where(type => type.IsClass && !type.IsAbstract && (baseTypes.Any(b => b.IsAssignableFrom(type))) || type.GetCustomAttribute<DependencyAttribute>() != null);
            foreach (var implementedInterType in types.Where(o=>!o.HasAttribute<IgnoreDependencyAttribute>()))
            {
                var attr = implementedInterType.GetCustomAttribute<DependencyAttribute>();
                var typeInfo = implementedInterType.GetTypeInfo();
                var serviceTypes = typeInfo.ImplementedInterfaces.Where(x => x.HasMatchingGenericArity(typeInfo)).Select(t => t.GetRegistrationType(typeInfo));

                var lifetime = GetServiceLifetime(implementedInterType);

                if (lifetime == null)
                {
                    break;
                }
                if (serviceTypes.Count() == 0)
                {
                    services.Add(new ServiceDescriptor(implementedInterType, implementedInterType, lifetime.Value));
                    break;
                }

                if (attr?.AddSelf == true)
                {
                    services.Add(new ServiceDescriptor(implementedInterType, implementedInterType, lifetime.Value));
                }

                foreach (var serviceType in serviceTypes.Where(o=>!o.HasAttribute<IgnoreDependencyAttribute>()))
                {
                    services.Add(new ServiceDescriptor(serviceType, implementedInterType, lifetime.Value));

                }
            }
            return services;
        }

        /// <summary>
        /// 将服务实现类型注册到服务集合中
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="implementationType">要注册的服务实例类型</param>
        protected virtual void AddToServices(IServiceCollection services, Type implementationType)
        {

            var atrr = implementationType.GetAttribute<DependencyAttribute>();
            Type[] serviceTypes = implementationType.GetImplementedInterfaces().Where(o=>!o.HasAttribute<IgnoreDependencyAttribute>()).ToArray();

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

        public override void Configure(IApplicationBuilder applicationBuilder)
        {
            IocManage.Instance.SetApplicationServiceProvider(applicationBuilder.ApplicationServices);
            base.Configure(applicationBuilder);
        }

    }
}
