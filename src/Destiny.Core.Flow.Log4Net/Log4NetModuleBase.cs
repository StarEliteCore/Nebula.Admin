using Destiny.Core.Flow.Modules;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Log4Net
{
    public abstract  class Log4NetModuleBase : AppModuleBase
    {

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            ///第一种用法
         
            services.AddTransient<Microsoft.Extensions.Logging.ILoggerFactory, LoggerFactory>();
            services.AddSingleton<ILoggerProvider, Log4NetProvider>();

            return services;
        }
    }
}
