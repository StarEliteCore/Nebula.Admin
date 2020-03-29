using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.SeriLog
{
    public class SeriLogLogger
    {
        private static ILogger _logger;
        public static void SetSeriLog(ILogger logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// SeriLog记录日志到文件
        /// </summary>
        /// <param name="MinimumLevel"></param>
        /// <param name="filename"></param>
        public static void SetSeriLoggerToFile(string MinimumLevel, string filename)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override(MinimumLevel, LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(filename, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        /// <summary>
        /// SeriLog记录日志到文件
        /// </summary>
        /// <param name="MinimumLevel"></param>
        /// <param name="filename"></param>
        public static void SetSeriLogToConsole(string MinimumLevel)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override(MinimumLevel, LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }


    }
}
