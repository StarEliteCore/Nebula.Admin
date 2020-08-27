using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.DbContexts
{
    public interface IMongoMongoDbContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<T> Collection<T>();
    }
}
