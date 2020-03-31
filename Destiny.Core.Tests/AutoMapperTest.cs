using AutoMapper;
using Destiny.Core.Flow.AutoMapper;
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Destiny.Core.Tests
{
    public  class AutoMapperTest:IClassFixture<CustomWebApplicationFactory<TestServerFixtureBase>>
    {

        private readonly CustomWebApplicationFactory<TestServerFixtureBase> _factory;

        public AutoMapperTest(CustomWebApplicationFactory<TestServerFixtureBase> factory)
        {
            _factory = factory;

        }

        [Fact]
        public void Test_AutoMapper()
        {
            var provider = _factory.Server.Services; //这垃圾测试
            Test test = new Test();

            test.Id = 1;
            test.Name = "18Cm大黄瓜";

           var dto=  test.MapTo<TestDto>();
            Assert.NotNull(dto);
            Assert.Equal("18Cm大黄瓜", dto.Name);

        }


    }

    public class TestAutoMapperModuleBase : AutoMapperModuleBase
    {
        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return base.ConfigureServices(services);
        }
    }

    public class Test
    { 
      public int Id { get; set; }

      public string Name { get; set; }
    }

    [AutoMap(typeof(Test))]
    public class TestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
  
}
