using System;

namespace Destiny.Core.Flow.Modules
{
    /// <summary>
    /// 依赖类型提供者
    /// </summary>
    public interface IDependedTypesProvider
    {
        /// <summary>
        /// 得到依赖类型集合
        /// </summary>
        /// <returns></returns>
        Type[] GetDependedTypes();
    }
}
