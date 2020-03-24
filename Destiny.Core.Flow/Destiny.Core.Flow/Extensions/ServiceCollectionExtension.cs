using Destiny.Core.Flow.Helpers;
using Microsoft.Extensions.DependencyInjection;
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
    public static class ServiceCollectionExtension
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
    }
}
