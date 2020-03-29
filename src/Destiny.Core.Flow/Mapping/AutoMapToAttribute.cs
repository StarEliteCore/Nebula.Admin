using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Mapping
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMapToAttribute : AutoMappAttribute
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
