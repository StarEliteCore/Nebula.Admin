using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Tests
{
   public abstract class TestBase
    {
        protected IServiceCollection Services { get; set; }
    }
}
