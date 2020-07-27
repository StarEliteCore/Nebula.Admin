using Destiny.Core.Flow.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    public static class AppModuleExtensions
    {

        public static IServiceCollection AddApplication<T>(this IServiceCollection services) where T : IAppModule 
        {


            services.AddApplication(typeof(T));
            return services;

        }

        private static IServiceCollection AddApplication(this IServiceCollection services,Type type)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

    
   
            var obj = new Objects<IApplicationBuilder>();
            services.Add(ServiceDescriptor.Singleton(typeof(Objects<IApplicationBuilder>), obj));
            services.Add(ServiceDescriptor.Singleton(typeof(IObjects<IApplicationBuilder>), obj));

            IStartupModuleRunner runner = new StartupModuleRunner(type,services);
            runner.ConfigureServices(services);

            return services;

        }

        public static IApplicationBuilder InitializeApplication(this IApplicationBuilder builder)
        {
            builder.ApplicationServices.GetRequiredService<Objects<IApplicationBuilder>>().Value = builder;
            var runner = builder.ApplicationServices.GetRequiredService<StartupModuleRunner>();
            runner.Initialize(builder.ApplicationServices);
            return builder;
        }

    }
}
