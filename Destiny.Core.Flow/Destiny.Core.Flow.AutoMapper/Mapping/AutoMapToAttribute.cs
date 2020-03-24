using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AutoMapper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMapToAttribute : AutoMapAttribute
    {
        public override AutoMapDirection Direciton
        {
            get { return AutoMapDirection.To; }
        }
        public AutoMapToAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }
    }
}
