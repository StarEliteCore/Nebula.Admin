using System;
using System.Collections.Generic;
using System.Text;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
 
namespace Destiny.Core.Flow.MiniProfiler
{
    public  class MiniProfilerModule : AppModule
    {
        private const string _name = "Destiny:IsOpenMiniProfiler";

        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            var isOpen = context.GetConfiguration()[_name].AsTo<bool>();
            if (isOpen.IsTrue())
            {
                app.UseMiniProfiler();
            }
          
            base.ApplicationInitialization(context);
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var isOpen=  context.GetConfiguration()[_name].AsTo<bool>();
            if (isOpen.IsTrue())
            {
               context.Services.AddMiniProfiler().AddEntityFramework();
            }
            base.ConfigureServices(context);
        }
    }
}
