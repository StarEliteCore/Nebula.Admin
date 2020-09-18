using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Options;

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
