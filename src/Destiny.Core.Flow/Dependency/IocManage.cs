using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Destiny.Core.Flow.Dependency
{
    /// <summary>
    /// Ioc管理
    /// </summary>
    public sealed class IocManage
    {
        private IServiceProvider _provider;

        private IServiceCollection _services;

        /// <summary>
        /// Ioc管理实例
        /// </summary>
        private static readonly Lazy<IocManage> InstanceLazy = new Lazy<IocManage>(() => new IocManage());

        private IocManage()
        {
        }

        public static IocManage Instance => InstanceLazy.Value;

        /// <summary>
        /// 设置应用程序服务提供者
        /// </summary>
        internal void SetApplicationServiceProvider(IServiceProvider provider)
        {
            provider.NotNull(nameof(provider));
            _provider = provider;
        }

        internal void SetServiceCollection(IServiceCollection services)
        {
            services.NotNull(nameof(services));
            _services = services;
        }

        /// <summary>
        /// 得到服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public T GetService<T>()
        {
            _provider.NotNull(nameof(_provider));
            _services.NotNull(nameof(_services));
            return _provider.GetService<T>();
        }

        /// <summary>
        /// 得到日志记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ILogger GetLogger<T>()
        {
            ILoggerFactory factory = _provider.GetService<ILoggerFactory>();
            return factory.CreateLogger<T>();
        }
    }
}