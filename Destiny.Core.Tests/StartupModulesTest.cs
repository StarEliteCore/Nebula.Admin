using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.TestBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Destiny.Core.Tests
{
   public class StartupModulesTest: IntegratedTest<TestModules>
    {

        public StartupModulesTest()
        {
            var test = ServiceProvider.GetService<TestModules>();
        }

       

        [Fact]
        public void Test_AddApplication()
        {
          
            //_services.AddApplication<TestModules>();
            //var runner= _services.BuildServiceProvider().GetRequiredService<IStartupModuleRunner>();
            //runner.Initialize(_services.BuildServiceProvider());
            // var test= _services.BuildServiceProvider().GetRequiredService<TestModules>();
            //Assert.True(test.ApplicationInitializationIsCalled);
            //Assert.True(test.ConfigureServicesIsCalled);
        }
    }

    [DependsOn(typeof(TestModules1),typeof(TestModules3))]
    public class TestModules : AppModule
    {
        public bool ConfigureServicesIsCalled { get; set; }
        public bool ApplicationInitializationIsCalled { get; set; }
        public override void ApplicationInitialization(ApplicationContext context)
        {
            ApplicationInitializationIsCalled = true;
            base.ApplicationInitialization(context);
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            ConfigureServicesIsCalled = true;
            base.ConfigureServices(context);
        }
    }


    public class TestModules1 : AppModule
    {

        public override void ApplicationInitialization(ApplicationContext context)
        {
            base.ApplicationInitialization(context);
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            base.ConfigureServices(context);
        }
    }

    [DependsOn(typeof(TestModules3))]
    public class TestModules2 : AppModule
    {

        public override void ApplicationInitialization(ApplicationContext context)
        {
            base.ApplicationInitialization(context);
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            base.ConfigureServices(context);
        }
    }

    [DependsOn(typeof(TestModules4))]
    public class TestModules3 : AppModule
    {

        public override void ApplicationInitialization(ApplicationContext context)
        {
            base.ApplicationInitialization(context);
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            base.ConfigureServices(context);
        }
    }

    public class TestModules4 : AppModule
    {

        public override void ApplicationInitialization(ApplicationContext context)
        {
            base.ApplicationInitialization(context);
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
