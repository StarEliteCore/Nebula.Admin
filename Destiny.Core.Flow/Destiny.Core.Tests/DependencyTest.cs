using Destiny.Core.Flow.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Destiny.Core.Flow.Extensions;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Mvc.Testing;
using Destiny.Core.Flow.Dependency;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Destiny.Core.Flow.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace Destiny.Core.Tests
{
    public class DependencyTest : IClassFixture<CustomWebApplicationFactory<TestServerFixtureBase>>
    {

        private readonly CustomWebApplicationFactory<TestServerFixtureBase>
    _factory;

        public DependencyTest(
            CustomWebApplicationFactory<TestServerFixtureBase> factory)
        {
            _factory = factory;
          
        }

        [Fact]
        public void Test_BulkInjection()
        {
            var provider = _factory.Server.Services;

          
        
            ////var list=  AppRuntimeAssembly.FindAllItems();
            //////var types=  ReflectHelper.GetAssemblies().SelectMany(o=>o.GetTypes());

            ////Type[] dependencyTypes = list.SelectMany(o=>o.GetTypes()).Where(type => type.IsClass && !type.IsAbstract && !type.IsInterface && type.HasAttribute<DependencyAttribute>()).ToArray();

            ////foreach (var dependencyType in dependencyTypes.Where(o => !o.IsAbstract || !o.IsInterface))
            ////{
            ////    var atrr = dependencyType.GetAttribute<DependencyAttribute>();
            ////    Type[] serviceTypes = dependencyType.GetImplementedInterfaces().ToArray();
            ////    if (serviceTypes.Length == 0)
            ////    {
            ////        services.TryAdd(new ServiceDescriptor(dependencyType, dependencyType, atrr.Lifetime));
            ////        continue;
            ////    }

            ////    if (atrr?.AddSelf == true)
            ////    {
            ////        services.TryAdd(new ServiceDescriptor(dependencyType, dependencyType, atrr.Lifetime));
            ////    }
            ////    foreach (var interfaceType in serviceTypes)
            ////    {

            ////        services.Add(new ServiceDescriptor(interfaceType, dependencyType, atrr.Lifetime));
            ////    }
            ////    //services.RegisterTypeAsImplementedInterfaces(dependencyType, atrr.Lifetime);
            ////}
            var test = provider.GetService<ITestScopedService>();
            Assert.NotNull(test);
            var getTest = test.GetTest();
            Assert.Equal("Test", getTest);

            var testTransientService = provider.GetService<ITestTransientService>();
            Assert.NotNull(testTransientService);
            var transient = testTransientService.GetTransientService();
            Assert.NotNull(transient);

            var testSingleton = provider.GetService<TestSingleton>();
            Assert.NotNull(testSingleton);


            var testService = provider.GetService<ITestService<User>>();
            Assert.NotNull(testService);

        }


    }

    public interface ITestScopedService
    {
        string GetTest();
    }

    [Dependency(ServiceLifetime.Scoped)]
    public class TestScopedService : ITestScopedService
    {

        public string GetTest()
        {
            return "Test";
        }
    }

    public interface ITestTransientService
    {
        string GetTransientService();
    }


    [Dependency(ServiceLifetime.Transient)]
    public class TestTransientService : ITestTransientService
    {
        public string GetTransientService()
        {

            return "测试成功";
        }
    }

    [Dependency(ServiceLifetime.Singleton)]
    public class TestSingleton
    {


    }
    public interface ITestService<User>
    {
    }
    [Dependency(ServiceLifetime.Scoped)]
    public class TestService : ITestService<User>
    {

    }



    public class User
    {

    }






}
