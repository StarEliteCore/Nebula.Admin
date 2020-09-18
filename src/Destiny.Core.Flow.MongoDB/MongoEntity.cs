using Destiny.Core.Flow.Entity;
using MongoDB.Bson;

namespace Destiny.Core.Flow
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {

        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}
