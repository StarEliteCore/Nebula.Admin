using Destiny.Core.Flow.Attributes.Base;
using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Events
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CacheKeyAttribute : AttributeBase
    {

        public CacheKeyAttribute(string key)
        {
            Key = key;
        }
        private string Key { get; set; }

        public override string Description()
        {
            
            return Key??string.Empty;
        }
    }
}
