using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{
    public  abstract class EntityFrameworkCoreModuleBase: AppModuleBase
    {



        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {


            services = UseSql(services);

            return services;
        }


        protected abstract IServiceCollection UseSql(IServiceCollection services);
    }
}
