using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Destiny.Core.Flow.Helpers;
using Nito.AsyncEx;

namespace Destiny.Core.Flow.Caching
{
    /// <summary>
    /// 缓存
    /// </summary>
    public class CacheDefault : ICache
    {

        private IDistributedCache _cache = null;
        private readonly AsyncLock _mutex = new AsyncLock();

        public CacheDefault(IDistributedCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 得到缓存
        /// </summary>
        /// <typeparam name="TCacheData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TCacheData Get<TCacheData>(string key)
        {

            return _cache.GetString(key).FromJson<TCacheData>();
        }

        public async Task<TCacheData> GetAsync<TCacheData>(string key, CancellationToken token = default)
        {

            return (await _cache.GetStringAsync(key)).FromJson<TCacheData>();
        }

        public TCacheData GetOrAdd<TCacheData>(string key, Func<TCacheData> func, int expireSeconds = -1)
        {
            key.NotNull(nameof(key));

            func.NotNull(nameof(func));

            using (_mutex.Lock())
            {
                var value = this.Get<TCacheData>(key);


                if (!Equals(value, default(TCacheData)))
                {
                    return value;
                }

                value = func();

                if (Equals(value, default(TCacheData)))
                {
                    return default;
                }

                Set(key, value, expireSeconds);
                return value;
            }

        }

        public async Task<TCacheData> GetOrAddAsync<TCacheData>([NotNull] string key, Func<Task<TCacheData>> func, int expireSeconds = -1, CancellationToken token = default)
        {
            key.NotNull(nameof(key));

            func.NotNull(nameof(func));

            using (await _mutex.LockAsync())
            {
                var value = await this.GetAsync<TCacheData>(key);


                if (!Equals(value, default(TCacheData)))
                {
                    return value;
                }

                value = await func();

                if (Equals(value, default(TCacheData)))
                {
                    return default;
                }

                await SetAsync(key, value);
                return value;
            }

        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public async Task RemoveAsync(string key, CancellationToken token = default)
        {
            await _cache.RemoveAsync(key);
        }

        public void Set<TCacheData>(string key, TCacheData value, int expireSeconds = -1)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            if (expireSeconds > 0)
            {
                options.SetAbsoluteExpiration(TimeSpan.FromSeconds(expireSeconds));
            }
            _cache.SetString(key, value.ToJson(), options);

        }

       
        public async Task SetAsync<TCacheData>(string key, TCacheData value, int expireSeconds = -1, CancellationToken token = default)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            if (expireSeconds > 0)
            {
                options.SetAbsoluteExpiration(TimeSpan.FromSeconds(expireSeconds));
            }
            await _cache.SetStringAsync(key, value.ToJson(), options);
        }
    }
}
