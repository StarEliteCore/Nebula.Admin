using Destiny.Core.Flow.MongoDB.Infrastructure;

namespace Destiny.Core.Flow.MongoDB
{
    public class MongoDbContextOptions : IMongoDbContextOptions
    {
        public string ConnectionString { get; set; }
    }
}
