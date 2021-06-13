using Destiny.Core.Flow.TestBase;
using DestinyCore.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore.TestBase
{
    public class AspNetCoreIntegratedTestBase<TStartup>: TestBaseWithServiceProvider
         where TStartup : class
    {

        protected TestServer Server { get; }

        protected HttpClient Client { get; }

        protected override IServiceProvider ServiceProvider { get; }

        protected AspNetCoreIntegratedTestBase()
        {
            var builder = CreateHostBuilder();

            var host = builder.Build();
            host.Start();

            Server = host.GetTestServer();
            Client = host.GetTestClient();

            ServiceProvider = Server.Services;

            ServiceProvider.GetRequiredService<ITestServerAccessor>().Server = Server;
        }


        protected virtual IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TStartup>();
                    webBuilder.UseTestServer();
                })
                .ConfigureServices(ConfigureServices);
        }

        protected virtual void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {

        }




        protected virtual string GetUrl<TController>()
        {
            return $"/{typeof(TController).Name.RemovePostFix("Controller")}";
        }

        protected virtual string GetUrl<TController>(string actionName)
        {
            return GetUrl<TController>() + "/" + actionName;
        }

        protected virtual string GetUrl<TController>(string actionName, object queryStringParamsAsAnonymousObject)
        {
            var url = GetUrl<TController>(actionName);

            var dictionary = new RouteValueDictionary(queryStringParamsAsAnonymousObject);
            if (dictionary.Any())
            {
                url += "?" + dictionary.Select(d => $"{d.Key}={d.Value}").ToJoin("&");
            }

            return url;
        }
    }
}
