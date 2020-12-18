using AspectCore.Extensions.Hosting;
using Destiny.Core.Flow.SeriLog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Destiny.Core.Flow.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            SeriLogLogger.SetSeriLoggerToFile("Logs",string.Empty);
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.ConfigureServices((web, s) =>
                    //{
                    //    web.HostingEnvironment.IsDevelopment();


                    //}).UseStartup<Startup>()
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
