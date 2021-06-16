
using DestinyCore.AspNetCore;
using DestinyCore.AspNetCore.Module;
using DestinyCore.Extensions;
using DestinyCore.Modules;
using DestinyCore.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.Startups
{
    [DependsOn(typeof(AspNetCoreModule))]
    public class MvcModule_Tests: AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddControllers(o=> {

                o.SuppressAsyncSuffixInActionNames = false;
            }).AddNewtonsoftJson(delegate (MvcNewtonsoftJsonOptions options)
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
        }

        public override void ApplicationInitialization(ApplicationContext context)
        {
            IApplicationBuilder applicationBuilder = context.GetApplicationBuilder();
            applicationBuilder.UseRouting();
        }
    }
}
