using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.SeriLog
{
    public abstract class SeriLogLoggerModuleBase:AppModuleBase
    {
        /// <summary>
        /// 注册SeriLog
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var serilog= services.GetService<ILogger>();
            SeriLogLogger.SetSeriLog(serilog);
            return services;
        }
    }
}
