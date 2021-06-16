
using DestinyCore.AutoMapper;
using DestinyCore.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Destiny.Core.Flow.AspNetCore.TestBase;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Shared.Abstractions;
using Destiny.Core.Flow.Shared.Application;

namespace Destiny.Core.AspNetMvc.Test.Startups
{
    [DependsOn
           (typeof(DestinyCoreConfigModule_Tests),
           typeof(MvcModule_Tests),
           typeof(EntityFrameworkCoreModule_Tests),
           typeof(AutoMapperModule)

    )]
    public class AppWebModule_Tests : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {

            context.Services.AddSingleton<ITestServerAccessor, TestServerAccessor>();
            context.Services.AddScoped(typeof(ICrudServiceAsync<,,,,>),typeof(CrudServiceAsync<,,,,>));
            
        }
    }
}
