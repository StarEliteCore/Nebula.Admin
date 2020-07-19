using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dependency
{

    public class DictionaryAccessor<TKey, TValue> : ConcurrentDictionary<TKey, TValue>, IDisposable
    {

     
        public virtual void Dispose()
        {
            this.Clear();
        }
    }


    public class DictionaryAccessor : ConcurrentDictionary<string, object>
    { 
    

        
    }
}
