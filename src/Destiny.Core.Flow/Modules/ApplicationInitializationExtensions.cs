using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
  public static  class ApplicationInitializationExtensions

    {

        public static IApplicationBuilder GetApplicationBuilder(this ApplicationContext applicationContext)
        {
           return   applicationContext.ServiceProvider.GetRequiredService<IObjectAccessor<IApplicationBuilder>>().Value;
        }



    



    }
}
