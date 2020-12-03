
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


        /// <summary>
        /// 得到配置文件
        /// </summary>
        /// <typeparam name="TOptionSettings"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TOptionSettings GetOptionSettings<TOptionSettings>(string key) where TOptionSettings : class
        {
            var configuration = this.GetConfiguration();
            var settings = configuration.GetSection(key).Get<TOptionSettings>();
            if (settings != null)
            {
                return settings;
            }

            return Services.GetObject<TOptionSettings>();
        }
    }
}
