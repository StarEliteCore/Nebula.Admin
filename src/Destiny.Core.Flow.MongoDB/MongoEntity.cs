using Destiny.Core.Flow.Entity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{
   public abstract class MongoEntity : IEntity<ObjectId>
    {

        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}
