using System;

namespace Destiny.Core.Flow.Modules
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    /// <summary>
    /// 依赖器
    /// </summary>
    public class DependsOnAttribute : Attribute, IDependedTypesProvider
    {
        /// <summary>
        /// 依赖类型集合
        /// </summary>
        private Type[] DependedTypes { get; }

        public DependsOnAttribute(params Type[] dependedTypes)
        {
            DependedTypes = dependedTypes ?? new Type[0];
        }
        /// <summary>
        ///  得到依赖类型集合
        /// </summary>
        /// <returns></returns>
        public virtual Type[] GetDependedTypes()
        {
            return DependedTypes;
        }

    }
}
