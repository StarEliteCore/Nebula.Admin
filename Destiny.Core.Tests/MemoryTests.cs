using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.TestBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Destiny.Core.Tests
{
  public  class MemoryTests : IntegratedTest<MemoryTestModelule>
    {
        ICache _cache = null;
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
            _cache.Set("Test",testCache);

            var value= _cache.Get<TestCacheItem>("Test");
            Assert.NotNull(value);
            Assert.True(value.Name== "大黄瓜18CM");
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
            context.Services.AddMemoryCache();
            context.Services.AddSingleton<ICache, MemoryCache>();
        }
    }
}
