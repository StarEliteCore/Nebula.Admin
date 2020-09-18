using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
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
    }
}
