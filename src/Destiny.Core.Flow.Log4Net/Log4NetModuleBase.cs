using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Destiny.Core.Flow.Log4Net
{
    public class Log4NetModule : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddTransient<Microsoft.Extensions.Logging.ILoggerFactory, LoggerFactory>();
            context.Services.AddSingleton<ILoggerProvider, Log4NetProvider>();
        }


    }
}
