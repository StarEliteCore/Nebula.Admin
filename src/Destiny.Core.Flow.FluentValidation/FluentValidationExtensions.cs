using Destiny.Core.Flow.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Destiny.Core.Flow.FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection WithFluentValidation(this IServiceCollection services)
        {
            services.AddTransient(typeof(IModelValidator<>), typeof(FluentValidationModelValidator<>));
            services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();

            return services;
        }





        /// <summary>
        /// 添加指定程序集中的所有验证程序
        /// </summary>
        /// <param name="services">服务的集合</param>
        /// <param name="assemblies"></param>
        /// <param name="lifetime">验证器的生存期。默认值是暂时的</param>
        /// <returns></returns>

        public static IServiceCollection AddValidatorsFromAssemblies(this IServiceCollection services,
            IEnumerable<Assembly> assemblies, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            foreach (var assembly in assemblies)
                services.AddValidatorsFromAssembly(assembly, lifetime);

            return services;
        }

        /// <summary>
        /// 添加指定程序集中的所有验证程序
        /// </summary>
        /// <param name="services">服务的集合</param>
        /// <param name="assembly">要扫描的程序集</param>
        /// <param name="lifetime">验证器的生存期。默认值是暂时的</param>
        /// <returns></returns>

        public static IServiceCollection AddValidatorsFromAssembly(this IServiceCollection services, Assembly assembly,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(scanResult => services.AddScanResult(scanResult, lifetime));

            return services;
        }


        /// <summary>
        /// 在指定类型的程序集中添加所有验证程序
        /// </summary>
        /// <param name="services">服务的集合</param>
        /// <param name="type">要扫描其程序集的类型</param>
        /// <param name="lifetime">验证器的生存期。默认值是暂时的</param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorsFromAssemblyContaining(this IServiceCollection services,
            Type type, ServiceLifetime lifetime = ServiceLifetime.Transient)
            => services.AddValidatorsFromAssembly(type.Assembly, lifetime);

        /// <summary>
        /// 添加泛型参数指定类型的程序集中的所有验证器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">服务的集合</param>
        /// <param name="lifetime">验证器的生存期。默认值是暂时的</param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorsFromAssemblyContaining<T>(this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            => services.AddValidatorsFromAssembly(typeof(T).Assembly, lifetime);

        /// <summary>
        /// 从AssemblyScanner结果注册验证器的帮助器方法
        /// </summary>
        /// <param name="services">服务的集合</param>
        /// <param name="scanResult">扫描结果</param>
        /// <param name="lifetime">验证器的生存期。默认值是暂时的</param>
        /// <returns></returns>
        private static IServiceCollection AddScanResult(this IServiceCollection services,
            AssemblyScanner.AssemblyScanResult scanResult, ServiceLifetime lifetime)
        {

            services.Add(
                new ServiceDescriptor(
                    scanResult.InterfaceType,
                    scanResult.ValidatorType,
                    lifetime));


            services.Add(
                new ServiceDescriptor(
                    scanResult.ValidatorType,
                    scanResult.ValidatorType,
                    lifetime));

            return services;
        }
    }
}
