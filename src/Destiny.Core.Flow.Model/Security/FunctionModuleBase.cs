using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.Security
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="BaseType"></typeparam>
    public  class FunctionModuleBase<BaseType> : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            IsAutoAddFunction = context.Services.GetAppSettings().IsAutoAddFunction;
            if (IsAutoAddFunction)
            {
                context.Services.AddSingleton<IFunctionHandler, FunctionHandler>();
            }


        }

        private bool IsAutoAddFunction { get; set; } = false;


        public override void ApplicationInitialization(ApplicationContext context)
        {

            var app = context.GetApplicationBuilder();
            if (IsAutoAddFunction)
            {
                context.ServiceProvider.GetService<IFunctionHandler>(t => t.Initialize<BaseType>());
            }
        }

      
    }
}
