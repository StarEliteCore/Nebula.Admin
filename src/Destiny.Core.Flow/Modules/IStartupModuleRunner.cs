using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    public interface IStartupModuleRunner: IModuleApplication
    {
         void ConfigureServices(IServiceCollection services);
        

        void Initialize(IServiceProvider service);
   
    }
}

