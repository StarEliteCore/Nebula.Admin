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


        public TestServerFixtureBase()
        {
            //var bulild = new WebHostBuilder().UseStartup<TestStartup>();
            //_testServer = new TestServer(bulild);
      
         
        }
        public void Dispose()
        {

        }


}


}
