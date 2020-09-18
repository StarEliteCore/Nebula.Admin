namespace Destiny.Core.Flow.MongoDB.Infrastructure
{
    public interface IMongoDbContextOptions
    {

        string ConnectionString { get; set; }
    }
}
