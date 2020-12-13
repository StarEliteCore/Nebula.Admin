using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow
{
    [DependsOn(
      typeof(MediatorAppModule)

   )]
    public  class EntityFrameworkCoreModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            AddDestinyDbContextWnitUnitOfWork(context.Services);
            AddRepository(context.Services);
        }

        

        /// <summary>
        /// 添加仓储
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected virtual IServiceCollection AddRepository(IServiceCollection services)
        {

            services.AddScoped(typeof(IEFCoreRepository<,>), typeof(Repository<,>));
            return services;
        }


        /// <summary>
        /// 添加上下文与工作单元
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

        protected virtual IServiceCollection AddDestinyDbContextWnitUnitOfWork(IServiceCollection services) {

            services.AddDestinyDbContext<DefaultDbContext>();
            services.AddUnitOfWork<DefaultDbContext>();
            return services;
        }

    }
}