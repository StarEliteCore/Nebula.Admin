using System.Diagnostics.CodeAnalysis;

namespace Destiny.Core.Flow.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {

        }

    }
}
