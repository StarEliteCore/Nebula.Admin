using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Modules
{
    public interface IModuleApplication : IDisposable
    {

        Type StartupModuleType { get; }

        IServiceCollection Services { get; }

        IServiceProvider ServiceProvider { get; }

        IReadOnlyList<IAppModule> Modules { get; }
    }
}
