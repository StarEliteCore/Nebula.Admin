using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AutoMapper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMapFromAttribute : AutoMapAttribute
    {
        public override AutoMapDirection Direciton
        {
            get { return AutoMapDirection.From; }
        }
        public AutoMapFromAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }
    }
}
