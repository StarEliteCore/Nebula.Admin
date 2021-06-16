using DestinyCore.Dependency;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore.TestBase
{
   public interface ITestServerAccessor: ISingletonDependency
    {
        TestServer Server { get; set; }
    }

    public class TestServerAccessor : ITestServerAccessor
    {
        public TestServer Server { get; set; }
    }
}
