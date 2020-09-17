using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow.Dependency
{
    public interface IIocManager
    {
        IServiceProvider Provider { get; set; }
        IServiceCollection Services { get; set; }
    }

    public class IocManager : IIocManager
    {
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services { get; set; }

        public IocManager(IServiceProvider provider)
        {
            Provider = provider;
        }
    }
}