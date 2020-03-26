using Destiny.Core.Flow.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.Tests
{
    public class AppServiceModuleTest
          : IClassFixture<CustomWebApplicationFactory<TestServerFixtureBase>>
    {

        private readonly CustomWebApplicationFactory<TestServerFixtureBase>
    _factory;

        public AppServiceModuleTest(
            CustomWebApplicationFactory<TestServerFixtureBase> factory)
        {
            _factory = factory;

        }


        [Fact]
        public void Test_AppServiceModule()
        {
            var module= _factory.Services.GetService<IAppServiceModuleManager>();
            var s=  _factory.IServiceCollection;
            module.LoadModules(s);


        }
    }
}
