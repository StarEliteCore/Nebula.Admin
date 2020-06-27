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
    public abstract class FunctionModuleBase<BaseType> : AppModuleBase
    {
        private bool IsAutoAddFunction { get; set; } = false;
        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            IsAutoAddFunction = services.GetAppSettings().IsAutoAddFunction;
            if (IsAutoAddFunction)
            {
                services.AddSingleton<IFunctionHandler, FunctionHandler>();
            }
            

       
            return services;
        }

        public override void Configure(IApplicationBuilder applicationBuilder)
        {
            if (IsAutoAddFunction)
            {
                applicationBuilder.ApplicationServices.GetService<IFunctionHandler>(t => t.Initialize<BaseType>());
            }
        
        }
    }
}
