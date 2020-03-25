using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Destiny.Core.Tests
{
    public class TestServerFixtureBase : IDisposable
    {
        public readonly TestServer _testServer;
        public HttpClient Client { get; }

        public TestServerFixtureBase()
        {
            var bulild = new WebHostBuilder().UseStartup<TestStartup>();
            _testServer = new TestServer(bulild);
      
            Client = _testServer.CreateClient();
        }
        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }

     
    }


}
