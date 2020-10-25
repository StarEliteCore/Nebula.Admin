using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow.Modules
{
    /// <summary>
    /// 应用上下文
    /// </summary>
    public class ApplicationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; set; }

        public ApplicationContext(IServiceProvider serviceProvider)
        {
            serviceProvider.NotNull(nameof(serviceProvider));
            ServiceProvider = serviceProvider;
        }
        public IConfiguration GetConfiguration()
        {
            return ServiceProvider.GetService<IConfiguration>();
        }
    }
}
