using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Caching
{
    public class MemoryCache : ICache
    {



        private IMemoryCache _cache = null;

        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public TCacheData Get<TCacheData>(string key)
        {

            return (TCacheData)_cache.Get(key);
        }

        public async Task<TCacheData> GetAsync<TCacheData>(string key, CancellationToken token = default)
        {

            return await Task.Run(() => (TCacheData)_cache.Get(key));
        }

        public TCacheData GetOrAdd<TCacheData>(string key, Func<TCacheData> func, int expireSeconds = -1)
        {
            key.NotNull(nameof(key));

            func.NotNull(nameof(func));
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

        public async Task<TCacheData> GetOrAddAsync<TCacheData>([NotNull] string key, Func<Task<TCacheData>> func, int expireSeconds = -1, CancellationToken token = default)
        {
            key.NotNull(nameof(key));

            func.NotNull(nameof(func));
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

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public async Task RemoveAsync(string key, CancellationToken token = default)
        {
            await Task.Run(() => this.Remove(key), token);
        }

        public void Set<TCacheData>(string key, TCacheData value, int expireSeconds = -1)
        {
            if (expireSeconds > 0)
            {
                _cache.Set(key, value, TimeSpan.FromSeconds(expireSeconds));
            }
            else
            {
                _cache.Set(key, value);
            }

        }

        public async Task SetAsync<TCacheData>(string key, TCacheData value, int expireSeconds = -1, CancellationToken token = default)
        {
            await Task.Run(() => this.Set<TCacheData>(key, value, expireSeconds), token);
        }
    }
}
