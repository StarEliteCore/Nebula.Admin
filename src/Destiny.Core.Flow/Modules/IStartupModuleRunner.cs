using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow.Modules
{
    public interface IStartupModuleRunner : IModuleApplication
    {
        void ConfigureServices(IServiceCollection services);


        void Initialize(IServiceProvider service);

    }
}

