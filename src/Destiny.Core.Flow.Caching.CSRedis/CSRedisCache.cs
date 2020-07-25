using Destiny.Core.Flow.Caching;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Destiny.Core.Flow.Extensions;
using System.Net.Http;

namespace Destiny.Core.Flow.Caching.CSRedis
{



    public class CSRedisCache : ICache
    {
        public TCacheData Get<TCacheData>(string key)
        {
           return  CacheHelper.Get<string,TCacheData>(key);
        }

        public async Task<TCacheData> GetAsync<TCacheData>(string key, CancellationToken token = default)
        {
     
            return await CacheHelper.GetAsync<string, TCacheData>(key);
        }

        public TCacheData GetOrAdd<TCacheData>(string key, Func<TCacheData> func)
        {
            return CacheHelper.GetOrAdd<string, TCacheData>(key, func);
        }

        public async Task<TCacheData> GetOrAddAsync<TCacheData>([NotNull] string key, Func<Task<TCacheData>> func, CancellationToken token = default)
        {
            return await CacheHelper.GetOrAddAsync<string, TCacheData>(key, func);
        }

        public void Remove(string key)
        {
            CacheHelper.Remove(key);
        }

        public async Task RemoveAsync(string key, CancellationToken token = default)
        {
           
            await CacheHelper.RemoveAsync(key);
        }

        public void Set<TCacheData>(string key, TCacheData value)
        {

            CacheHelper.Set(key,value);
        }

        public async Task SetAsync<TCacheData>(string key, TCacheData value, CancellationToken token = default)
        {
         
            await CacheHelper.SetAsync(key, value);
        }
    }
}
