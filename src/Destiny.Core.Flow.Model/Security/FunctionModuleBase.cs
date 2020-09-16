using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.Flow.Model.Security
{
    /// <summary>
    /// </summary>
    /// <typeparam name="BaseType"></typeparam>
    public class FunctionModuleBase<BaseType> : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            IsAutoAddFunction = context.GetAppSettings().IsAutoAddFunction;
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