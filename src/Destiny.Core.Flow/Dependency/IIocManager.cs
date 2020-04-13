using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dependency
{
   public  interface IIocManager
    {
        IServiceProvider Provider { get; set; }
    }

    public class IocManager : IIocManager
    {

        public IServiceProvider Provider { get; set; }
        public IocManager(IServiceProvider provider)
        {
            Provider = provider;
        }

    }
}
