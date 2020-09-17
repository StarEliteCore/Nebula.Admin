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

        //public override IServiceCollection ConfigureServices(IServiceCollection services)
        //{
        //    services = UseSql(services);
        //    services= AddUnitOfWork(services);
        //    services = AddRepository(services);
        //    return services;
        //}

        protected abstract IServiceCollection AddUnitOfWork(IServiceCollection services);

        protected abstract IServiceCollection AddRepository(IServiceCollection services);

        protected abstract IServiceCollection UseSql(IServiceCollection services);
    }
}