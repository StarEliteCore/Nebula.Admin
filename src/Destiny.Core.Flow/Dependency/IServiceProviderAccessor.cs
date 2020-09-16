using System;

namespace Destiny.Core.Flow.Dependency
{
    /// <summary>
    /// 服务提供者访问器
    /// </summary>
    public interface IServiceProviderAccessor
    {
        IServiceProvider ServiceProvider { get; }
    }
}