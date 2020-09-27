using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Destiny.Core.Flow.Modules
{
    public abstract class ModuleApplicationBase : IModuleApplication
    {
        public Type StartupModuleType { get; set; }

        public IServiceCollection Services { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        public IReadOnlyList<IAppModule> Modules { get; }
        private List<IAppModule> _source = new List<IAppModule>();

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
        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private List<IAppModule> GetAllModule(IServiceCollection services)
        {
            var typeFinder = services.GetOrAddSingletonService<ITypeFinder, TypeFinder>();
            var typs = typeFinder.Find(o => AppModule.IsAppModule(o));

            var modules = typs.Select(o => CreateModule(services, o)).Distinct();
            return modules.ToList();
        }

        protected virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
        }
        /// <summary>
        /// 获取需要加载的模块
        /// </summary>
        /// <returns></returns>
        private IReadOnlyList<IAppModule> LoadModules()
        {
            List<IAppModule> modules = new List<IAppModule>();

            var module = _source.FirstOrDefault(o => o.GetType() == StartupModuleType);
            if (module == null)
            {
                throw new AppException($"类型为“{StartupModuleType.FullName}”的模块实例无法找到");
            }


            modules.Add(module);

            var dependeds = module.GetDependedTypes();
            foreach (var dependType in dependeds.Where(o => AppModule.IsAppModule(o)))
            {
                var dependModule = _source.ToList().Find(m => m.GetType() == dependType);
                if (dependModule == null)
                {
                    throw new AppException($"加载模块{module.GetType().FullName}时无法找到依赖模块{dependType.FullName}");
                }

                modules.AddIfNotContains(dependModule);

            }
            return modules;

        }
        /// <summary>
        /// 注册模块
        /// </summary>
        /// <param name="services"></param>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        private IAppModule CreateModule(IServiceCollection services, Type moduleType)
        {

            var module = (IAppModule)Expression.Lambda(Expression.New(moduleType)).Compile().DynamicInvoke();
            services.AddSingleton(moduleType, module);
            return module;
        }
        public virtual void Dispose()
        {

        }
    }
}
