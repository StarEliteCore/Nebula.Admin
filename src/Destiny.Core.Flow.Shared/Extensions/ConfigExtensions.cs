using DestinyCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Shared.Extensions
{
    public static class ConfigExtensions
    {
        public static IConfiguration Build<TOptions>(this IServiceCollection services, string key, TOptions option, Action<TOptions> actionOptions) where TOptions : class
        {

            var configuration = services.GetConfiguration();

            if (configuration == null)
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                configuration = configurationBuilder.Build();
                services.AddSingleton<IConfiguration>(configuration);
            }
            else
            {
                configuration.Bind(key, option);
                services.AddObjectAccessor(option);
                if (actionOptions !=null)
                {
                    services.Configure<TOptions>(actionOptions);
                } else
                {
                    services.Configure<TOptions>(configuration.GetSection(key));
                }
                //services.AddObjectAccessor(option);
             
            }
            return configuration;
        }
    }
}
