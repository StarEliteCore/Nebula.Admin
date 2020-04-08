using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.DependencyInjection;
using Destiny.Core.Flow.AOP;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    public class AspNetCoreAOPModule: AppModuleBase
    {
        /// <summary>
        /// AOP事务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {

            //return services.AddSingleton<IAopManager>(provider =>
            // {

            //     var aopManager= new AopManager();
            //     aopManager.AutoLoadAops(services);
            //     return aopManager;
            // });
            return services;
        }

    


    }
}
