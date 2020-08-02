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

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            IocManage.Instance.SetServiceCollection(services);
            services = AddAutoInjection(services);
            return services;
        }

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


        private ServiceLifetime? GetServiceLifetime(Type type)
        {
            var attr = type.GetCustomAttribute<DependencyAttribute>();
            if (attr != null)
            {
                return attr.Lifetime;
            }

            if (typeof(IScopedDependency).IsAssignableFrom(type))
            {
                return ServiceLifetime.Scoped;
            }

            if (typeof(ITransientDependency).IsAssignableFrom(type))
            {
                return ServiceLifetime.Transient;
            }


            if (typeof(ISingletonDependency).IsAssignableFrom(type))
            {
                return ServiceLifetime.Singleton;
            }

            return null;
        }


        public override void Configure(IApplicationBuilder applicationBuilder)
        {
            IocManage.Instance.SetApplicationServiceProvider(applicationBuilder.ApplicationServices);
            base.Configure(applicationBuilder);
        }

    }
}
