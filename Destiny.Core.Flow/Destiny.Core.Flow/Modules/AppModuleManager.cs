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
 
    public class AppModuleManager: IAppModuleManager
    {
        public List<AppModuleBase> SourceModules { get; private set; }
        public AppModuleManager()
        {
            SourceModules = new List<AppModuleBase>();
        }
        /// <summary>
        /// 加载模块(注册模块ss)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceCollection LoadModules(IServiceCollection services)
        {
            var typeFinder = services.GetOrAddSingletonService<ITypeFinder, TypeFinder>();
            var baseType = typeof(AppModuleBase);
            var moduleTypes = typeFinder.Find(t=> t.IsSubclassOf(baseType)&&!t.IsAbstract).Distinct().ToArray();
            if (moduleTypes?.Count() <= 0)
            {
                throw new AppException("没有找到要加载的模块!!");
            }
            SourceModules.Clear();
            var moduleBases = moduleTypes.Select(m => (AppModuleBase)Activator.CreateInstance(m));
            SourceModules.AddRange(moduleBases);
            List<AppModuleBase> modules = SourceModules.ToList();
            foreach (var module in modules)
            {
                services = module.ConfigureServices(services);
            }
            return services;
        }
        public void  Configure(IApplicationBuilder applicationBuilder)
        {
            foreach (var module in SourceModules)
            {
                module.Configure(applicationBuilder);
            }
        }
    }
}
