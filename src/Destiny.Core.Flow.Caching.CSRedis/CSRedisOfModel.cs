using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Caching.CSRedis
{
    public class CSRedisCache<TCacheData> : CSRedisCache<string, TCacheData>, ICache<TCacheData>
               where TCacheData : class
    {

    }
    public class CSRedisCache<TKey, TCacheData> :
        ICache<TKey, TCacheData>
         where TCacheData : class
    {

  
        public TCacheData Get(TKey key)
        {

            return Helper.Get<TKey,TCacheData>(key);
        }

        public async Task<TCacheData> GetAsync(TKey key, CancellationToken token = default)
        {

            return await Helper.GetAsync<TKey, TCacheData>(key);
        }

        public TCacheData GetOrAdd(TKey key, Func<TCacheData> func)
        {

            return Helper.GetOrAdd(key,func);
        }

        public async Task<TCacheData> GetOrAddAsync([NotNull] TKey key, Func<Task<TCacheData>> func, CancellationToken token = default)
        {


            return await Helper.GetOrAddAsync(key, func);
        }

        public void Remove(TKey key)
        {

            Helper.Remove(key);
        }

        public async Task RemoveAsync(TKey key, CancellationToken token = default)
        {

             await Helper.RemoveAsync(key);
        }

        public void Set(TKey key, TCacheData value)
        {
            Helper.Set(key,value);
        }

        public async Task SetAsync(TKey key, TCacheData value, CancellationToken token = default)
        {
            await Helper.SetAsync(key, value);
        }
    }
}
