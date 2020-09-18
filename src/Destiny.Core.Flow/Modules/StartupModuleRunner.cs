using Destiny.Core.Flow.Dependency;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow.Modules
{
    public class StartupModuleRunner : ModuleApplicationBase, IStartupModuleRunner
    {
        public StartupModuleRunner(Type startupModuleType, IServiceCollection services)
            : base(startupModuleType, services)
        {

            services.AddSingleton<IStartupModuleRunner>(this);

        }
        /// <summary>
        /// 程序启动时加载模块中的配置
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            IocManage.Instance.SetServiceCollection(services);
            var ctx = new ConfigureServicesContext(services);
            services.AddSingleton(ctx);
            foreach (var cfg in Modules)
            {
                services.AddSingleton(cfg);
                cfg.ConfigureServices(ctx);
            }
        }
        /// <summary>
        /// 加载应用程序
        /// </summary>
        /// <param name="service"></param>
        public void Initialize(IServiceProvider service)
        {
            IocManage.Instance.SetApplicationServiceProvider(service);
            SetServiceProvider(service);
            using var scope = ServiceProvider.CreateScope();
            //using var scope = service.CreateScope();
            var ctx = new ApplicationContext(scope.ServiceProvider);
            foreach (var cfg in Modules)
            {
                cfg.ApplicationInitialization(ctx);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (ServiceProvider is IDisposable disposableServiceProvider)
            {
                disposableServiceProvider.Dispose();
            }
        }
    }
}
