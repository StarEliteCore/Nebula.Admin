using Destiny.Core.Flow.MongoDB;
using Destiny.Core.Flow.MongoDB.DbContexts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Destiny.Core.Flow.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {

        }

    }
}
