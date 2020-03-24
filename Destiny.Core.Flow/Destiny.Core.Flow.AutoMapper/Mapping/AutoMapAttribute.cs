using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Text;


namespace Destiny.Core.Flow.AutoMapper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMapAttribute : Attribute
    {

        public Type[] TargetTypes { get; private set; }
        public virtual AutoMapDirection Direciton
        {
            get { return AutoMapDirection.From | AutoMapDirection.To; }
        }

        public AutoMapAttribute(params Type[] targetTypes)
        {
            targetTypes.NotNull(nameof(targetTypes));
            TargetTypes = targetTypes;
        }

    }
}
