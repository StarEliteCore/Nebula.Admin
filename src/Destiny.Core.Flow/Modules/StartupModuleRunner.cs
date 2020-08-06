using Destiny.Core.Flow.Dependency;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
  public  class StartupModuleRunner: ModuleApplicationBase, IStartupModuleRunner
    {
        public StartupModuleRunner(Type startupModuleType, IServiceCollection services)
            : base(startupModuleType,services)
        {

            services.AddSingleton<IStartupModuleRunner>(this);

        }
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
