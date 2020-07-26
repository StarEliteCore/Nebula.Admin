using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Extensions.Hosting;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.SeriLog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Destiny.Core.Flow.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            SeriLogLogger.SetSeriLoggerToFile("Logs", "http://1065.cloud:9600/");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                // ÅäÖÃÏîÒýÈëapollo
                builder.AddApollo(builder.Build().GetSection("apollo"))
                .AddNamespace("application")
                 .AddDefault(ConfigFileFormat.Json)
                .AddDefault();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSerilog()
                   .ConfigureLogging((hostingContext, builder) =>
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
