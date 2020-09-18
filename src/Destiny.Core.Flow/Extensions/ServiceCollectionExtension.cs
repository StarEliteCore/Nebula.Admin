using Destiny.Core.Flow.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Destiny.Core.Flow.Extensions
{

    public static partial class Extensions
    {

        /// <summary>
        /// 得到注入服务
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static TType GetService<TType>(this IServiceCollection services)
        {

            var provider = services.BuildServiceProvider();
            return provider.GetService<TType>();
        }
        /// <summary>
        /// 得到或添加Singleton服务
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>


        public static TServiceType GetOrAddSingletonService<TServiceType, TImplementation>(this IServiceCollection services)
    where TServiceType : class
where TImplementation : class, TServiceType
        {



            var type = services.GetSingletonInstanceOrNull<TServiceType>();
            if (type is null)
            {
                var provider = services.BuildServiceProvider();
                var serviceType = (TServiceType)provider.GetInstance(new ServiceDescriptor(typeof(TServiceType), typeof(TImplementation), ServiceLifetime.Singleton));
                return serviceType;
            }

            return type;
        }

        /// <summary>
        /// 得到或添加Singleton服务
        /// </summary>
        /// <typeparam name="TServiceType"></typeparam>

        public static TServiceType GetOrAddSingletonService<TServiceType>(this IServiceCollection services, Func<TServiceType> factory) where TServiceType : class
        {


            var servciceType = services.GetSingletonInstanceOrNull<TServiceType>();
            if (servciceType is null)
            {
                servciceType = factory();
                services.AddSingleton<TServiceType>(servciceType);
            }

            return servciceType;
        }


        /// <summary>
        /// 得到操作设置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

        public static AppOptionSettings GetAppSettings(this IServiceCollection services)
        {
            services.NotNull(nameof(services));
            return services.GetService<IOptions<AppOptionSettings>>()?.Value;
        }

        public static IConfiguration GetConfiguration(this IServiceCollection services)
        {

            return services.GetService<IConfiguration>();
        }



        public static T GetSingletonInstanceOrNull<T>(this IServiceCollection services)
        {
            var servictType = services
                .FirstOrDefault(d => d.ServiceType == typeof(T) && d.Lifetime == ServiceLifetime.Singleton);
            if (servictType?.ImplementationInstance != null)
            {
                return (T)servictType.ImplementationInstance;
            }

            if (servictType?.ImplementationFactory != null)
            {
                return (T)servictType.ImplementationFactory.Invoke(null);
            }

            return default(T);
        }

        public static T GetSingletonInstance<T>(this IServiceCollection services)
        {
            var service = services.GetSingletonInstanceOrNull<T>();
            if (service == null)
            {
                throw new InvalidOperationException("找不到singleton服务: " + typeof(T).AssemblyQualifiedName);
            }

            return service;
        }

        public static IServiceProvider BuildServiceProviderFromFactory([NotNull] this IServiceCollection services)
        {


            foreach (var service in services)
            {
                var factoryInterface = service.ImplementationInstance?.GetType()
                    .GetTypeInfo()
                    .GetInterfaces()
                    .FirstOrDefault(i => i.GetTypeInfo().IsGenericType &&
                                         i.GetGenericTypeDefinition() == typeof(IServiceProviderFactory<>));

                if (factoryInterface == null)
                {
                    continue;
                }

                var containerBuilderType = factoryInterface.GenericTypeArguments[0];
                return (IServiceProvider)typeof(Extensions)
                    .GetTypeInfo()
                    .GetMethods()
                    .Single(m => m.Name == nameof(BuildServiceProviderFromFactory) && m.IsGenericMethod)
                    .MakeGenericMethod(containerBuilderType)
                    .Invoke(null, new object[] { services, null });
            }

            return services.BuildServiceProvider();
        }


        public static IServiceProvider ConfigureProvider(this IServiceCollection services, Action<IServiceCollection> configure)
        {
            configure(services);

            return services.BuildServiceProviderFromFactory();
        }

    }
}
