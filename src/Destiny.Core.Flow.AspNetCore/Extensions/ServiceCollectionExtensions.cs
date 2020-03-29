using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.Extensions;

namespace Destiny.Core.Flow.AspNetCore
{
    public static  class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加模块管理
        /// </summary>
        /// <typeparam name="TAppModuleManager"></typeparam>
        /// <param name="services"></param>
        public static IServiceCollection AddAppModuleManager<TAppModuleManager>(this IServiceCollection services)
            where TAppModuleManager : IAppModuleManager, new()
        {
            services.NotNull(nameof(services));
            services.AddSingleton<IAssemblyFinder, AssemblyFinder>();
            TAppModuleManager module = new TAppModuleManager();
            services.AddSingleton<IAppModuleManager>(module);
            module.LoadModules(services);
            return services;

        }
    }
}
