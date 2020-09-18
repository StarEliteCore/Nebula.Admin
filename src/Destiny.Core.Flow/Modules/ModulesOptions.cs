using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.Flow.Modules
{
    public class ModulesOptions
    {

        public IServiceCollection Service { get; }

        public ModulesOptions(IServiceCollection service)
        {
            Service = service;
        }
    }
}
