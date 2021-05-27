using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.TestBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Destiny.Core.Tests
{
    public class MemoryTests : IntegratedTest<MemoryTestModelule>
    {
        private ICache _cache = null;
        public MemoryTests()
        {
            _cache = ServiceProvider.GetService<ICache>();
        }


        [Fact]
        public void SetOrGetCache_Test()
        {
            TestCacheItem testCache = new TestCacheItem();
            testCache.TestId = Guid.NewGuid().ToString();
            testCache.Name = "大黄瓜18CM";
            _cache.Set("Test", testCache);

            var value = _cache.Get<TestCacheItem>("Test");
            Assert.NotNull(value);
            Assert.True(value.Name == "大黄瓜18CM");
        }

        [Fact]

        public async Task SetOrGetCasheListAsync_Test()
        {

            List<TestCacheItem> list = new List<TestCacheItem>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(new TestCacheItem
                {

                    TestId = Guid.NewGuid().ToString(),
                    Name = "大黄瓜_{i}"
                });
            }

            await _cache.SetAsync("Tests", list);
            var caches = await _cache.GetAsync<List<TestCacheItem>>("Tests");
            Assert.True(caches.Count == 100);
        }

        [Fact]
        public async Task GetOrAddAsync_Test()
        {

            var newTestCache = await _cache.GetOrAddAsync<TestCacheItem>("getOrAddAsync", async () =>
            {

                await Task.CompletedTask;
                TestCacheItem testCache = new TestCacheItem();
                testCache.TestId = Guid.NewGuid().ToString();
                testCache.Name = "帅气大黄瓜";
                return testCache;
            });
            Assert.Equal(newTestCache.Name, "帅气大黄瓜");

        }


        [Fact]
        public void GetOrAdd_Test()
        {

            var newTestCache = _cache.GetOrAdd<TestCacheItem>("getOrAdd", () =>
            {

                TestCacheItem testCache = new TestCacheItem();
                testCache.TestId = Guid.NewGuid().ToString();
                testCache.Name = "帅气大黄瓜1";
                return testCache;
            });
            Assert.Equal(newTestCache.Name, "帅气大黄瓜1");

        }


        [Fact]
        public async Task RemoveAsync_Test()
        {

            await _cache.RemoveAsync("getOrAddAsync");
            var test = await _cache.GetAsync<TestCacheItem>("getOrAddAsync");
            Assert.Null(test);
        }

        [Fact]

        public async Task ExpireSeconds_Test()
        {

            await _cache.SetAsync("expireSeconds","dfdff",10);
            var test = await _cache.GetAsync<string>("expireSeconds");
            Assert.NotNull(test);
            await Task.Delay(TimeSpan.FromSeconds(10));
            var test1= await _cache.GetAsync<string>("expireSeconds");
            Assert.Null(test1);
        }



    }


    public class TestCacheItem
    {
        public string TestId { get; set; }

        public string Name { get; set; }
    }


    public class MemoryTestModelule : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddDistributedMemoryCache();
            context.Services.AddSingleton<ICache, CacheDefault>();
        }
    }
}
