using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.MongoDB.Infrastructure
{
    public interface IMongoDbContextOptions
    {

        string ConnectionString { get; set; }
    }
}
