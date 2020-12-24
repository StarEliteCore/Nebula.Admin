using AspectCore.Extensions.Hosting;
using Destiny.Core.Flow.SeriLog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace Destiny.Core.Flow.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //SeriLogLogger.SetSeriLoggerToFile("Logs",string.Empty);
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                 //待封装
                 .UseSerilog((webHost, configuration) => {
                    
                     //得到配置文件
                     var serilog= webHost.Configuration.GetSection("Serilog");
                     //最小级别
                     var minimumLevel =serilog["MinimumLevel:Default"];
                     //日志事件级别
                     var logEventLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), minimumLevel);


                     configuration.ReadFrom.
                     Configuration(webHost.Configuration.GetSection("Serilog")).Enrich.FromLogContext().WriteTo.Console(logEventLevel);
                     configuration.WriteTo.Map(le => MapData(le),
             (key, log) =>
              log.Async(o => o.File(Path.Combine("Logs", @$"{key.time:yyyy-MM-dd}\{key.level.ToString().ToLower()}.txt"), logEventLevel)));

                     (DateTime time, LogEventLevel level) MapData(LogEvent logEvent)
                     {

                         return (new DateTime(logEvent.Timestamp.Year, logEvent.Timestamp.Month, logEvent.Timestamp.Day, logEvent.Timestamp.Hour, logEvent.Timestamp.Minute, logEvent.Timestamp.Second), logEvent.Level);
                     }

                 }).ConfigureLogging((hostingContext, builder) =>
                 {
                     builder.ClearProviders();
                     builder.SetMinimumLevel(LogLevel.Information);

                     builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     builder.AddConsole();
                     builder.AddDebug();
                 });
                }).UseDynamicProxy();//*/;//aspcectcore;


    }
}
