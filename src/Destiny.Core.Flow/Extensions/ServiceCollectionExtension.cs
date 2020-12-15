using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

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
            return services.GetSingletonInstanceOrNull<IOptions<AppOptionSettings>>()?.Value;
        }

        public static IConfiguration GetConfiguration(this IServiceCollection services)
        {

            return services.GetSingletonInstanceOrNull<IConfiguration>();
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





        /// <summary>
        /// 得到文件容器
        /// </summary>
        /// <param name="services">服务接口</param>
        /// <param name="fileName">文件名+后缀名</param>
        /// <param name="fileNotExistsMsg">文件不存提示信息</param>
        /// <returns>返回文件中的文件</returns>
        public static string GetFileText(this IServiceCollection services, string fileName, string fileNotExistsMsg)
        {
            fileName.NotNullOrEmpty(nameof(fileName));
            var fileProvider = services.GetSingletonInstanceOrNull<IFileProvider>();

            if (fileProvider == null)
            {

                throw new AppException("IFileProvider接口不存在");
            }


            var fileInfo = fileProvider.GetFileInfo(fileName);
            if (!fileInfo.Exists)
            {
                if (!fileNotExistsMsg.IsNullOrEmpty())
                {
                    throw new AppException(fileNotExistsMsg);
                }

            }
            var text = ReadAllText(fileInfo);
            if (text.IsNullOrEmpty())
            {
                throw new AppException("文件内容不存在");
            }
            return text;
        }

        /// <summary>
        /// 根据配置得到文件内容
        /// </summary>
        /// <param name="services">服务接口</param>
        /// <param name=""></param>
        /// <param name="sectionKey">分区键</param>
        /// <param name="fileNotExistsMsg">文件不存提示信息</param>
        /// <returns>返回文件中的文件</returns>
        public static string GetFileByConfiguration(this IServiceCollection services, string sectionKey, string fileNotExistsMsg)
        {


            sectionKey.NotNullOrEmpty(nameof(sectionKey));
            var configuration = services.GetService<IConfiguration>();
            var value = configuration?.GetSection(sectionKey)?.Value;
            return services.GetFileText(value, fileNotExistsMsg);

        }

        /// <summary>
        /// 读取全部文本
        /// </summary>
        /// <param name="fileInfo">文件信息接口</param>
        /// <returns></returns>
        private static string ReadAllText(IFileInfo fileInfo)
        {
            byte[] buffer;
            using var stream = fileInfo.CreateReadStream();
            buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return Encoding.Default.GetString(buffer).Trim();
        }

        /// <summary>
        /// 添加文件提供器
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFileProvider(this IServiceCollection services)
        {

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            return services.AddSingleton<IFileProvider>(new PhysicalFileProvider(basePath));

        }


        /// <summary>
        /// 添加延迟工厂
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLazyFactory(this IServiceCollection services)
        {
            return services.AddTransient(typeof(Lazy<>), typeof(LazyFactory<>));
        }


        /// <summary>
        /// 得到实例类型集合
        /// </summary>
        /// <typeparam name="TServiceType"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetImplementationTypes<TServiceType>(this IServiceCollection services)
        {

           return services.Where(o => o.ServiceType == typeof(TServiceType) && o.Lifetime == ServiceLifetime.Singleton).Select(o=>o.ImplementationType);
        }

     

    }
}
