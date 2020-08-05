using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Modules;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Log4Net
{
    public   class Log4NetModule :AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddTransient<Microsoft.Extensions.Logging.ILoggerFactory, LoggerFactory>();
            context.Services.AddSingleton<ILoggerProvider, Log4NetProvider>();
        }

     
    }
}
