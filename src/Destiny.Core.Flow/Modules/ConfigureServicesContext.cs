using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    /// <summary>
    /// 配置服务上下文
    /// </summary>
    public class ConfigureServicesContext
    {
        public ConfigureServicesContext(IServiceCollection services)
        {
            Services = services;

        }
        public IServiceCollection Services { get; }
    }
}
