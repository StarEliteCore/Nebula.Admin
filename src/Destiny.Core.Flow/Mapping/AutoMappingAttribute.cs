using Destiny.Core.Flow.Extensions;
using System;


namespace Destiny.Core.Flow.Mapping
{
    /// <summary>
    /// 为什么要取这个名字因为跟AutoMapper重复
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMappingAttribute : Attribute
    {

        public Type[] TargetTypes { get; private set; }
        public virtual AutoMapDirection Direciton
        {
            get { return AutoMapDirection.From | AutoMapDirection.To; }
        }

        public AutoMappingAttribute(params Type[] targetTypes)
        {
            targetTypes.NotNull(nameof(targetTypes));
            TargetTypes = targetTypes;
        }

    }
}
