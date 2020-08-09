using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
   public static class ConfigureServicesContextExtenstions
    {

        public static AppOptionSettings GetAppSettings(this ConfigureServicesContext services)
        {
            return services.Services.GetObject<AppOptionSettings>();
        }
    }
}
