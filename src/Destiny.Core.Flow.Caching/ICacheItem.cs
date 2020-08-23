using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Caching
{
    public interface ICacheItem
    {

        string NormalizeKey(string key);
    }

    public abstract class CacheItemBase : ICacheItem
    {
        public abstract string NormalizeKey(string key);

    
    }
}
