using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
namespace Destiny.Core.Flow.AspNetCore
{
   public static class ApplicationBuilderExtensions
    {
        public static void UseAppModule<TModuleManager>(this IApplicationBuilder app)
           where TModuleManager : IAppModuleManager
        {

            var moduleManager = app.ApplicationServices.GetService<IAppModuleManager>();
            var modules = moduleManager.SourceModules;
            foreach (var module in modules)
            {

                module.Configure(app);
            }
        }
    }
}
