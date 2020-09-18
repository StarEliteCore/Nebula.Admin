using Destiny.Core.Flow.Attributes.Base;
using Destiny.Core.Flow.Extensions;
using System;
using System.Reflection;

namespace Destiny.Core.Flow.Caching
{
    /// <summary>
    /// 缓存键名前缀
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CachePrefixAttribute : AttributeBase
    {

        public CachePrefixAttribute(string prefix)
        {
            prefix.NotNullOrEmpty(nameof(prefix));
            Prefix = prefix;
        }
        private string Prefix { get; set; }
        public override string Description()
        {

            return Prefix;
        }

        public static string GetCachePrefix(Type cacheType)
        {


            var attribute = cacheType.GetCustomAttribute<CachePrefixAttribute>();
            if (attribute != null)
            {
                return attribute.Prefix;
            }
            return cacheType.FullName.RemovePostFix("CacheItem");
        }
    }
}
