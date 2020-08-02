using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    public abstract class ModuleApplicationBase : IModuleApplication
    {
        public Type StartupModuleType { get; set; }

        public IServiceCollection Services { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        public IReadOnlyList<IAppModule> Modules { get; }
        private  List<IAppModule> _source= new List<IAppModule>();

        public ModuleApplicationBase(Type startupModuleType, IServiceCollection services)
        {
            StartupModuleType = startupModuleType;
            Services = services;
            services.TryAddSingleton<IAssemblyFinder, AssemblyFinder>();
            services.TryAddSingleton<ITypeFinder, TypeFinder>();
            services.AddSingleton<IModuleApplication>(this);
            services.TryAddObjectAccessor<IServiceProvider>();
            _source = this.GetAllModule(services);
           
            Modules = LoadModules();
        }

        private List<IAppModule> GetAllModule(IServiceCollection services)
        {
          var typeFinder=   services.GetOrAddSingletonService<ITypeFinder, TypeFinder>();
          var typs=  typeFinder.Find(o=> AppModule.IsAppModule(o));
      
          var modules= typs.Select(o => CreateModule(services, o)).Distinct();
          return modules.ToList();
        }

        protected virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
        }
        private IReadOnlyList<IAppModule> LoadModules()
        {
            List<IAppModule> modules = new List<IAppModule>();

            var module = _source.FirstOrDefault(o => o.GetType() == StartupModuleType);
            if (module == null)
            {
                throw new Exception($"类型为“{StartupModuleType.FullName}”的模块实例无法找到");
            }
            modules.Add(module);

            var dependeds = module.GetDependedTypes();
            foreach (var dependType in dependeds.Where(o=> AppModule.IsAppModule(o)))
            {
                var dependModule = _source.ToList().Find(m => m.GetType() == dependType);
                if (dependModule == null)
                {
                    throw new Exception($"加载模块{module.GetType().FullName}时无法找到依赖模块{dependType.FullName}");
                }

                modules.AddIfNotContains(dependModule);

            }
            return modules;

        }

        private IAppModule CreateModule(IServiceCollection services, Type moduleType)
        {

           var module= /*(IAppModule)Activator.CreateInstance(moduleType)*/(IAppModule)Expression.Lambda(Expression.New(moduleType)).Compile().DynamicInvoke();
           services.AddSingleton(moduleType, module);
            return module;
        }
        public virtual void Dispose()
        {
           
        }
    }
}
