
using Destiny.Core.Flow.EntityFrameworkCore;
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
            services= AddUnitOfWork(services);
            services = AddRepository(services);
            return services;
        }

        protected abstract IServiceCollection AddUnitOfWork(IServiceCollection services);


        protected abstract IServiceCollection AddRepository(IServiceCollection services);
 


        protected abstract IServiceCollection UseSql(IServiceCollection services);
    }
}
