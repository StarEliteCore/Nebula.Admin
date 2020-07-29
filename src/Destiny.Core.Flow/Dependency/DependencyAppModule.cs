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
            this.BulkIntoServices(services);
            return services;
        }
        /// <summary>
        /// 批量注入服务
        /// </summary>
        /// <param name="services"></param>
        private void BulkIntoServices(IServiceCollection services)
        {

            var typeFinder = services.GetOrAddSingletonService<ITypeFinder, TypeFinder>();
            typeFinder.NotNull(nameof(typeFinder));
            Type[] baseTypes = new[] { typeof(ISingletonDependency), typeof(IScopedDependency), typeof(ITransientDependency) };
            Type[] dependencyTypes = typeFinder.Find(type => type.IsClass && !type.IsAbstract && !type.IsInterface && (type.HasAttribute<DependencyAttribute>()|| (baseTypes.Any(b => b.IsAssignableFrom(type)))));
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
            if (implementationType.IsAbstract || implementationType.IsInterface)
            {
                return;
            }
            var lifetime=  GetServiceLifetime(implementationType);
            if (lifetime == null)
            {
                return;
            }
              var atrr = implementationType.GetAttribute<DependencyAttribute>();
         
             Type[] serviceTypes = implementationType.GetImplementedInterfaces().Where(t=>!t.HasAttribute<IgnoreDependencyAttribute>()).ToArray();

            if (serviceTypes.Length == 0)
            {
                services.TryAdd(new ServiceDescriptor(implementationType, implementationType, lifetime.Value));
                return;
            }

            if (atrr?.AddSelf == true)
            {
                services.TryAdd(new ServiceDescriptor(implementationType, implementationType, lifetime.Value));
            }


            for (int i = 0; i < serviceTypes.Length; i++)
            {
                Type serviceType = serviceTypes[i];
                ServiceDescriptor descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime.Value);

                services.Add(descriptor);
            }
        }


        private ServiceLifetime? GetServiceLifetime(Type type)
        {
            var dependency = type.GetAttribute<DependencyAttribute>();
            if (dependency != null)
            {
                return dependency.Lifetime;
            }

            if (type.IsDeriveClassFrom<ISingletonDependency>())
            {
               return  ServiceLifetime.Singleton;
            }

            if (type.IsDeriveClassFrom<ITransientDependency>())
            {
                return ServiceLifetime.Transient;
            }

            if (type.IsDeriveClassFrom<IScopedDependency>())
            {
                return ServiceLifetime.Scoped;
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
