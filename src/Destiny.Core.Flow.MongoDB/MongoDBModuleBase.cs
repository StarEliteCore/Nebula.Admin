using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.MongoDB.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Destiny.Core.Flow
{
    public abstract class MongoDBModuleBase : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {

            AddDbContext(context.Services);
            AddRepository(context.Services);
        }





        public virtual void AddRepository(IServiceCollection services)
        {

            services.TryAddScoped(typeof(IMongoDBRepository<,>), typeof(MongoDBRepository<,>));
        }



        protected abstract void AddDbContext(IServiceCollection services);
    }
}
