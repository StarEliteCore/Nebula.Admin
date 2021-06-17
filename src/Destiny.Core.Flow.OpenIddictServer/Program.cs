using AspectCore.Extensions.Hosting;
using Destiny.Core.Flow.SeriLog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Destiny.Core.Flow.OpenIddictServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SeriLogLogger.SetSeriLoggerToFile("Logs", string.Empty);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceContext()//Ê¹ÓÃaspectcoreÌæ»»ioc
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSerilog()
                     .ConfigureLogging((hostingContext, builder) =>
                     {
                         builder.ClearProviders();
#if DEBUG
                         builder.SetMinimumLevel(LogLevel.Debug);
#else
                         builder.SetMinimumLevel(LogLevel.Information);
#endif

                         builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                         builder.AddConsole();
                         builder.AddDebug();
                     });
                });
    }
}
