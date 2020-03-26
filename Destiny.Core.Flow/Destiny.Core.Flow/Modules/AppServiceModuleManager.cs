using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    [Dependency(ServiceLifetime.Scoped)]
    public class AppServiceModuleManager: IAppServiceModuleManager
    {
        public List<AppServiceModuleBase> SourceModules { get; private set; }

        public IEnumerable<AppServiceModuleBase> LoadedModules { get; private set; }

        public AppServiceModuleManager()
        {
            SourceModules = new List<AppServiceModuleBase>();
            LoadedModules = new List<AppServiceModuleBase>();
        }

        public IServiceCollection LoadModules(IServiceCollection services)
        {

            var moduleTypes = AppRuntimeAssembly.FindAllItems().SelectMany(o=>o.GetTypes()).Where(o => o.IsDeriveClassFrom<AppServiceModuleBase>()).Distinct().ToArray().Select(o => o.BaseType).Where(t => t.IsNotNull() && t.IsClass && !t.IsAbstract).ToArray();
            if (moduleTypes?.Count() <= 0)
            {
                throw new AppException("没有找到要加载的模块!!");
            }
            SourceModules.Clear();
            var moduleBases = moduleTypes.Select(m => (AppServiceModuleBase)Activator.CreateInstance(m));
            SourceModules.AddRange(moduleBases);
            List<AppServiceModuleBase> modules = SourceModules.ToList();

            LoadedModules = modules;

            foreach (var module in LoadedModules)
            {
                services = module.ConfigureServices(services);

            }
            return services;

        }

        //此方法由运行时调用。使用此方法配置HTTP请求管道。
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            foreach (var module in LoadedModules)
            {
                module.Configure(applicationBuilder);
            }
        }
    }
}
