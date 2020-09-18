using Destiny.Core.Flow.Attributes.Base;
using Destiny.Core.Flow.Extensions;
using System;
using System.Reflection;

namespace Destiny.Core.Flow.Caching
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CacheNameAttribute : AttributeBase
    {

        public CacheNameAttribute(string name)
        {
            Name = name;
        }
        private string Name { get; set; }

        public override string Description()
        {

            return Name ?? string.Empty;
        }


        public static string GetCacheName(Type cacheType)
        {


            var cacheNameAttribute = cacheType.GetCustomAttribute<CacheNameAttribute>();
            if (cacheNameAttribute != null)
            {
                return cacheNameAttribute.Name;
            }
            return cacheType.FullName.RemovePostFix("CacheItem");
        }



    }
}
