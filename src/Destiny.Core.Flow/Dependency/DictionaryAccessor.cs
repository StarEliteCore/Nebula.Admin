using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dependency
{


    [Dependency(ServiceLifetime.Scoped,AddSelf =true)]

    public class DictionaryAccessor : ConcurrentDictionary<string, object>, IDisposable
    {
        public bool ddd { get; set; }

        public virtual void Dispose()
        {
            this.Clear();
        }

    }
}
