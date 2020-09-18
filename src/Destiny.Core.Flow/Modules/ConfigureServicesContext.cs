
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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


        public IConfiguration GetConfiguration()
        {

            var implemenInstance = Services.GetSingletonInstanceOrNull<IConfiguration>();
            return implemenInstance;
        }


        public TValue GetConfiguration<TValue>(string key)
        {

            return GetConfigurationSection(key).Get<TValue>();
        }
        public IConfigurationSection GetConfigurationSection(string key)
        {
            key.NotNullOrEmpty(nameof(key));
            return this.GetConfiguration()?.GetSection(key);
        }
    }
}
