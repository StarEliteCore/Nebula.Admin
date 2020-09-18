using Destiny.Core.Flow.Attributes.Base;
using System;

namespace Destiny.Core.Flow.Filter
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FilterCodeAttribute : AttributeBase
    {
        public FilterCodeAttribute(string code)
        {
            Code = code;


        }
        public string Code { get; set; }

        public override string Description()
        {

            return this.Code;
        }
    }
}
