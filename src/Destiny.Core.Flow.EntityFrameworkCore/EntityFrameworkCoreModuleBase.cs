using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.Flow
{
    public abstract class EntityFrameworkCoreModuleBase : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            UseSql(context.Services);
            AddUnitOfWork(context.Services);
            AddRepository(context.Services);
        }

        /// <summary>
        /// 添加工作单元
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

        protected virtual IServiceCollection AddUnitOfWork(IServiceCollection services)
        {

            return services.AddUnitOfWork<DefaultDbContext>();


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

        protected abstract IServiceCollection UseSql(IServiceCollection services);
    }
}