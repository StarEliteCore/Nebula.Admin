
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Helpers;
using Destiny.Core.Flow.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Extensions
{
    public interface IServiceModule
    {
        void ConfigureServices(IServiceCollection services);
    }
    public static partial class Extensions
    {
        /// <summary>
        /// RegisterAssemblyTypes
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services, params Assembly[] assemblies)
            => RegisterAssemblyTypes(services, null, ServiceLifetime.Singleton, assemblies);
        /// <summary>
        /// RegisterAssemblyTypes
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="serviceLifetime">service lifetime</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services,
            ServiceLifetime serviceLifetime, params Assembly[] assemblies)
            => RegisterAssemblyTypes(services, null, serviceLifetime, assemblies);
        /// <summary>
        /// RegisterAssemblyTypes
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="typesFilter">filter types to register</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services,
            Func<Type, bool> typesFilter, params Assembly[] assemblies)
            => RegisterAssemblyTypes(services, typesFilter, ServiceLifetime.Singleton, assemblies);
        /// <summary>
        /// RegisterAssemblyTypes
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="typesFilter">filter types to register</param>
        /// <param name="serviceLifetime">service lifetime</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services, Func<Type, bool> typesFilter, ServiceLifetime serviceLifetime, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
            {
                assemblies = ReflectHelper.GetAssemblies();
            }

            var types = assemblies
                .Select(assembly => assembly.GetExportedTypes())
                .SelectMany(t => t);
            if (typesFilter != null)
            {
                types = types.Where(typesFilter);
            }

            foreach (var type in types)
            {
                services.Add(new ServiceDescriptor(type, type, serviceLifetime));
            }

            return services;
        }
        /// <summary>
        /// RegisterTypeAsImplementedInterfaces
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypesAsImplementedInterfaces(this IServiceCollection services,
            params Assembly[] assemblies)
            => RegisterAssemblyTypesAsImplementedInterfaces(services, typesFilter: null, ServiceLifetime.Singleton, assemblies);
        /// <summary>
        /// RegisterTypeAsImplementedInterfaces
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="serviceLifetime">service lifetime</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypesAsImplementedInterfaces(this IServiceCollection services,
            ServiceLifetime serviceLifetime, params Assembly[] assemblies)
            => RegisterAssemblyTypesAsImplementedInterfaces(services, typesFilter: null, serviceLifetime, assemblies);
        /// <summary>
        /// RegisterTypeAsImplementedInterfaces, singleton by default
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="typesFilter">filter types to register</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypesAsImplementedInterfaces(this IServiceCollection services, Func<Type, bool> typesFilter, params Assembly[] assemblies)
            => RegisterAssemblyTypesAsImplementedInterfaces(services, typesFilter: typesFilter, ServiceLifetime.Singleton, assemblies);

        /// <summary>
        /// RegisterTypeAsImplementedInterfaces
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="typesFilter">filter types to register</param>
        /// <param name="serviceLifetime">service lifetime</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyTypesAsImplementedInterfaces(this IServiceCollection services, Func<Type, bool> typesFilter, ServiceLifetime serviceLifetime, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
            {
                assemblies = ReflectHelper.GetAssemblies();
            }

            var types = assemblies
                .Select(assembly => assembly.GetExportedTypes())
                .SelectMany(t => t);
            if (typesFilter != null)
            {
                types = types.Where(typesFilter);
            }

            foreach (var type in types)
            {
                foreach (var implementedInterface in type.GetImplementedInterfaces())
                {
                    services.Add(new ServiceDescriptor(implementedInterface, type, serviceLifetime));
                }
            }

            return services;
        }
        /// <summary>
        /// RegisterTypeAsImplementedInterfaces
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="type">type</param>
        /// <param name="serviceLifetime">service lifetime</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterTypeAsImplementedInterfaces(this IServiceCollection services, Type type, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            if (type != null)
            {

                foreach (var interfaceType in type.GetImplementedInterfaces())
                {
                    services.Add(new ServiceDescriptor(interfaceType, type, serviceLifetime));
                }
            }
            return services;
        }
        /// <summary>
        /// RegisterAssemblyModules
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="assemblies">assemblies</param>
        /// <returns>services</returns>
        public static IServiceCollection RegisterAssemblyModules(
            [NotNull] this IServiceCollection services, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
            {
                assemblies = ReflectHelper.GetAssemblies();
            }
            foreach (var type in assemblies.SelectMany(ass => ass.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IServiceModule).IsAssignableFrom(t))
            )
            {
                try
                {
                    if (Activator.CreateInstance(type) is IServiceModule module)
                    {
                        module.ConfigureServices(services);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return services;
        }
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
        public static TType GetOrAddSingletonService<TType, TImplementation>(this IServiceCollection services) where TType : class
       where TImplementation : class, TType
        {
            var type = services.GetService<TType>();
            if (type is null)
            {
                services.AddSingleton<TType, TImplementation>();
                type = services.GetService<TType>();
            }

            return type;
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
            var servictType= services
                .FirstOrDefault(d => d.ServiceType == typeof(T)&&d.Lifetime== ServiceLifetime.Singleton);
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

        /// <summary>
        /// 装饰 <typeparamref name="TService"/>类型的所有注册服务
        /// 使用指定的类型。 <typeparamref name="TDecorator"/>.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <exception cref="MissingTypeRegistrationException">如果尚未注册 <typeparamref name="TService"/> 类型的服务.</exception>
        /// <exception cref="ArgumentNullException">If the <paramref name="services"/> argument is <c>null</c>.</exception>
        public static IServiceCollection Decorate<TService, TDecorator>(this IServiceCollection services)
            where TDecorator : TService
        {
            services.NotNull(nameof(services));

            return services.DecorateDescriptors(typeof(TService), x => x.Decorate(typeof(TDecorator)));
        }

        /// <summary>
        /// 装饰所有类型的注册服务 <typeparamref name="TService"/>
        /// 使用指定类型 <typeparamref name="TDecorator"/>.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/> 参数为 <c>空</c>.</exception>
        public static bool TryDecorate<TService, TDecorator>(this IServiceCollection services)
            where TDecorator : TService
        {
            services.NotNull(nameof(services));

            return services.TryDecorateDescriptors(typeof(TService), out _, x => x.Decorate(typeof(TDecorator)));
        }

        /// <summary>
        /// 装饰所有类型的注册服务 <paramref name="serviceType"/>
        /// 使用指定类型 <paramref name="decoratorType"/>.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="serviceType">装修服务类型.</param>
        /// <param name="decoratorType">用以装饰现有服务的类型.</param>
        /// <exception cref="MissingTypeRegistrationException">如果没有指定的服务 <paramref name="serviceType"/> 已注册。</exception>
        /// <exception cref="ArgumentNullException">如果<paramref name="services"/>,
        /// <paramref name="serviceType"/> 或 <paramref name="decoratorType"/> 参数为 <c>空</c>.</exception>
        public static IServiceCollection Decorate(this IServiceCollection services, Type serviceType, Type decoratorType)
        {
            services.NotNull(nameof(services));
            serviceType.NotNull(nameof(serviceType));
            decoratorType.NotNull(nameof(decoratorType));
       

            if (serviceType.IsOpenGeneric() && decoratorType.IsOpenGeneric())
            {
                return services.DecorateOpenGeneric(serviceType, decoratorType);
            }

            return services.DecorateDescriptors(serviceType, x => x.Decorate(decoratorType));
        }

        /// <summary>
        /// 装饰指定的 <paramref name="serviceType"/>
        /// 使用指定的 <paramref name="decoratorType"/>.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="serviceType">装修服务类型.</param>
        /// <param name="decoratorType">用以装饰现有服务的类型.</param>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>,
        /// <paramref name="serviceType"/> 或 <paramref name="decoratorType"/> 参数为  <c>空</c>.</exception>
        public static bool TryDecorate(this IServiceCollection services, Type serviceType, Type decoratorType)
        {
            services.NotNull(nameof(services));
            serviceType.NotNull(nameof(serviceType));
            decoratorType.NotNull(nameof(decoratorType));

            if (serviceType.IsOpenGeneric() && decoratorType.IsOpenGeneric())
            {
                return services.TryDecorateOpenGeneric(serviceType, decoratorType, out _);
            }

            return services.TryDecorateDescriptors(serviceType, out _, x => x.Decorate(decoratorType));
        }

        /// <summary>
        ///装饰所有类型的注册服务 <typeparamref name="TService"/>
        /// 使用 <paramref name="decorator"/> 函数.
        /// </summary>
        /// <typeparam name="TService">装修服务类型.</typeparam>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="MissingTypeRegistrationException">如果没有服务<typeparamref name="TService"/>已注册.</exception>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>
        ///或<paramref name="decorator"/> 参数为 <c>空</c>.</exception>
        public static IServiceCollection Decorate<TService>(this IServiceCollection services, Func<TService, IServiceProvider, TService> decorator)
        {
            services.NotNull(nameof(services));
            decorator.NotNull(nameof(decorator));

            return services.DecorateDescriptors(typeof(TService), x => x.Decorate(decorator));
        }

        /// <summary>
        /// 装饰所有类型的注册服务 <typeparamref name="TService"/>
        /// 使用<paramref name="decorator"/> 函数.
        /// </summary>
        /// <typeparam name="TService">装修服务类型.</typeparam>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>
        ///或<paramref name="decorator"/> 参数为 <c>空</c>.</exception>
        public static bool TryDecorate<TService>(this IServiceCollection services, Func<TService, IServiceProvider, TService> decorator)
        {
            services.NotNull(nameof(services));
            decorator.NotNull(nameof(decorator));


            return services.TryDecorateDescriptors(typeof(TService), out _, x => x.Decorate(decorator));
        }

        /// <summary>
        /// 装饰所有类型的注册服务 <typeparamref name="TService"/>
        /// 使用 <paramref name="decorator"/> 函数.
        /// </summary>
        /// <typeparam name="TService">装修服务类型.</typeparam>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="MissingTypeRegistrationException">如果没有服务 <typeparamref name="TService"/> 已注册.</exception>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>
        ///或<paramref name="decorator"/> 参数为<c>空</c>.</exception>
        public static IServiceCollection Decorate<TService>(this IServiceCollection services, Func<TService, TService> decorator)
        {
            services.NotNull(nameof(services));
            decorator.NotNull(nameof(decorator));


            return services.DecorateDescriptors(typeof(TService), x => x.Decorate(decorator));
        }

        /// <summary>
        /// 装饰所有类型的注册服务e <typeparamref name="TService"/>
        /// 使用 <paramref name="decorator"/> 函数.
        /// </summary>
        /// <typeparam name="TService">装修服务类型.</typeparam>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>
        ///或<paramref name="decorator"/> 参数为 <c>空</c>.</exception>
        public static bool TryDecorate<TService>(this IServiceCollection services, Func<TService, TService> decorator)
        {
            services.NotNull(nameof(services));
            decorator.NotNull(nameof(decorator));


            return services.TryDecorateDescriptors(typeof(TService), out _, x => x.Decorate(decorator));
        }

        /// <summary>
        /// 装饰指定的 <paramref name="serviceType"/>
        /// 使用 <paramref name="decorator"/> 函数.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="serviceType">装修服务类型.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="MissingTypeRegistrationException">如果没有指定的服务 <paramref name="serviceType"/> 已注册.</exception>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>,
        /// <paramref name="serviceType"/>或<paramref name="decorator"/> 参数为 <c>空</c>.</exception>
        public static IServiceCollection Decorate(this IServiceCollection services, Type serviceType, Func<object, IServiceProvider, object> decorator)
        {
            services.NotNull(nameof(services));
            serviceType.NotNull(nameof(serviceType));
            decorator.NotNull(nameof(decorator));

            return services.DecorateDescriptors(serviceType, x => x.Decorate(decorator));
        }

        /// <summary>
        /// 装饰指定的 <paramref name="serviceType"/>
        /// 使用 <paramref name="decorator"/> 函数.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="serviceType">装修服务类型.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>,
        /// <paramref name="serviceType"/>或<paramref name="decorator"/> 参数为 <c>空</c>.</exception>
        public static bool TryDecorate(this IServiceCollection services, Type serviceType, Func<object, IServiceProvider, object> decorator)
        {
            services.NotNull(nameof(services));
            serviceType.NotNull(nameof(serviceType));
            decorator.NotNull(nameof(decorator));

            return services.TryDecorateDescriptors(serviceType, out _, x => x.Decorate(decorator));
        }

        /// <summary>
        /// 装饰指定的 <paramref name="serviceType"/>
        /// 使用 <paramref name="decorator"/> 函数.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="serviceType">装修服务类型.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="MissingTypeRegistrationException">如果没有指定的服务 <paramref name="serviceType"/> 已注册.</exception>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>,
        /// <paramref name="serviceType"/>或<paramref name="decorator"/> 参数为 <c>空</c>.</exception>
        public static IServiceCollection Decorate(this IServiceCollection services, Type serviceType, Func<object, object> decorator)
        {
            services.NotNull(nameof(services));
            serviceType.NotNull(nameof(serviceType));
            decorator.NotNull(nameof(decorator));

            return services.DecorateDescriptors(serviceType, x => x.Decorate(decorator));
        }

        /// <summary>
        /// 装饰指定的 <paramref name="serviceType"/>
        /// 使用 <paramref name="decorator"/> 函数.
        /// </summary>
        /// <param name="services">要添加到的服务.</param>
        /// <param name="serviceType">装修服务类型.</param>
        /// <param name="decorator">装饰函数.</param>
        /// <exception cref="ArgumentNullException">如果 <paramref name="services"/>,
        /// <paramref name="serviceType"/>或<paramref name="decorator"/> 参数为 <c>空</c>.</exception>
        public static bool TryDecorate(this IServiceCollection services, Type serviceType, Func<object, object> decorator)
        {
            services.NotNull(nameof(services));
            serviceType.NotNull(nameof(serviceType));
            decorator.NotNull(nameof(decorator));
            return services.TryDecorateDescriptors(serviceType, out _, x => x.Decorate(decorator));
        }

        private static IServiceCollection DecorateOpenGeneric(this IServiceCollection services, Type serviceType, Type decoratorType)
        {
            if (services.TryDecorateOpenGeneric(serviceType, decoratorType, out var error))
            {
                return services;
            }

            throw error;
        }

        private static bool IsSameGenericType(Type t1, Type t2)
        {
            return t1.IsGenericType && t2.IsGenericType && t1.GetGenericTypeDefinition() == t2.GetGenericTypeDefinition();
        }

        private static bool TryDecorateOpenGeneric(this IServiceCollection services, Type serviceType, Type decoratorType, [NotNullWhen(false)] out Exception? error)
        {
            var arguments = services
                .Where(x => !x.ServiceType.IsGenericTypeDefinition)
                .Where(x => IsSameGenericType(x.ServiceType, serviceType))
                .Select(x => x.ServiceType.GenericTypeArguments)
                .ToArray();

            if (arguments.Length == 0)
            {
                error = new MissingTypeRegistrationException(serviceType);
                return false;
            }

            foreach (var argument in arguments)
            {
                var closedServiceType = serviceType.MakeGenericType(argument);
                var closedDecoratorType = decoratorType.MakeGenericType(argument);

                if (!services.TryDecorateDescriptors(closedServiceType, out error, x => x.Decorate(closedDecoratorType)))
                {
                    return false;
                }
            }

            error = default;
            return true;
        }

        private static IServiceCollection DecorateDescriptors(this IServiceCollection services, Type serviceType, Func<ServiceDescriptor, ServiceDescriptor> decorator)
        {
            if (services.TryDecorateDescriptors(serviceType, out var error, decorator))
            {
                return services;
            }

            throw error;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="error"></param>
        /// <param name="decorator"></param>
        /// <returns></returns>
        private static bool TryDecorateDescriptors(this IServiceCollection services, Type serviceType, [NotNullWhen(false)] out Exception? error, Func<ServiceDescriptor, ServiceDescriptor> decorator)
        {
            if (!services.TryGetDescriptors(serviceType, out var descriptors))
            {
                error = new MissingTypeRegistrationException(serviceType);
                return false;
            }

            foreach (var descriptor in descriptors)
            {
                var index = services.IndexOf(descriptor);

                // 为了避免对描述符重新排序，在需要特定顺序的情况下.
                services[index] = decorator(descriptor);
            }

            error = default;
            return true;
        }

        private static bool TryGetDescriptors(this IServiceCollection services, Type serviceType, out ICollection<ServiceDescriptor> descriptors)
        {
            return (descriptors = services.Where(service => service.ServiceType == serviceType).ToArray()).Any();
        }

        private static ServiceDescriptor Decorate<TService>(this ServiceDescriptor descriptor, Func<TService, IServiceProvider, TService> decorator)
        {
            // TODO: 在预览8结束时用notnull注释TService.
            return descriptor.WithFactory(provider => decorator((TService)provider.GetInstance(descriptor), provider)!);
        }

        private static ServiceDescriptor Decorate<TService>(this ServiceDescriptor descriptor, Func<TService, TService> decorator)
        {
            // TODO: 在预览8结束时用notnull注释TService.
            return descriptor.WithFactory(provider => decorator((TService)provider.GetInstance(descriptor))!);
        }

        private static ServiceDescriptor Decorate(this ServiceDescriptor descriptor, Type decoratorType)
        {
            return descriptor.WithFactory(provider => provider.CreateInstance(decoratorType, provider.GetInstance(descriptor)));
        }

        private static ServiceDescriptor WithFactory(this ServiceDescriptor descriptor, Func<IServiceProvider, object> factory)
        {
            return ServiceDescriptor.Describe(descriptor.ServiceType, factory, descriptor.Lifetime);
        }


        public static Type GetImplementationType(this ServiceDescriptor descriptor)
        {


            if (descriptor.ImplementationType != null)
            {
                return descriptor.ImplementationType;
            }

            if (descriptor.ImplementationInstance != null)
            {
                return descriptor.ImplementationInstance.GetType();
            }

            return descriptor.ImplementationFactory?.GetType().GetTypeInfo().GenericTypeArguments[1];
        }


        public static IServiceProvider ConfigureProvider(this IServiceCollection services, Action<IServiceCollection> configure)
        {
            configure(services);

            return services.BuildServiceProviderFromFactory();
        }

    }
}
