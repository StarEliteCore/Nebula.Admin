using Destiny.Core.Flow.MongoDB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.MongoDB
{
    public class MongoDbContextOptions : IMongoDbContextOptions
    {
        public string ConnectionString { get; set; }
    }
}
