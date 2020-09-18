using Destiny.Core.Flow.MongoDB;
using Destiny.Core.Flow.MongoDB.DbContexts;
using JetBrains.Annotations;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MongoDBServiceCollectionExtensions
    {

        public static IServiceCollection AddMongoDbContext<TContext>(this IServiceCollection services, [CanBeNull] Action<MongoDbContextOptions> optionsAction) where TContext : MongoDbContextBase
        {
            MongoDbContextOptions options = new MongoDbContextOptions();
            optionsAction(options);
            services.AddSingleton<MongoDbContextOptions>(options);
            services.AddScoped<MongoDbContextBase, TContext>();
            return services;
        }
    }
}
