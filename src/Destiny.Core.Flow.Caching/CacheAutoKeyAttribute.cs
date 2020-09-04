using Destiny.Core.Flow.Attributes.Base;
using Destiny.Core.Flow.Extensions;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Caching
{
    /// <summary>
    /// 得到缓存key
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CacheAutoKeyAttribute : Attribute
    {

        public static string GetCacheKey(Type cacheType)
        {
           
            var values = cacheType.GetProperties().Where(o => o.HasAttribute<CacheAutoKeyAttribute>()).Select(pi => pi.GetValue(cacheType));

            var key = values.Join("-");
            return key;

        }
    }
}
