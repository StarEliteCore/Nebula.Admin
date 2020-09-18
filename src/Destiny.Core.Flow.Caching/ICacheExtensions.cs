using Destiny.Core.Flow.Extensions;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Caching
{
    /// <summary>
    /// 缓存扩展
    /// </summary>
    public static class CacheExtensions
    {

        private static string GetKey<TCacheData>(TCacheData data)
              where TCacheData : ICacheItem
        {
            var parameter = Expression.Parameter(typeof(TCacheData), "o");

            //var value = Expression.Lambda<Func<TCacheData, string>>(parameter, new ParameterExpression[] { parameter }).Compile().Invoke(test);
            var preFix = CachePrefixAttribute.GetCachePrefix(typeof(TCacheData));
            var values = data.GetType().GetProperties().Where(o => o.HasAttribute<CacheAutoKeyAttribute>())
                .Select(pi =>
                {

                    var pr = Expression.Property(parameter, pi);
                    return Expression.Lambda<Func<TCacheData, string>>(pr, new ParameterExpression[] {
                    parameter
                    }).Compile().Invoke(data);
                }
                );

            var key = values.Join("-");
            return $"{preFix}{key}";

        }











        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Set<TCacheData>(this ICache cache, TCacheData value)
             where TCacheData : class, ICacheItem
        {
            var key = GetKey(value);
            cache.Set<TCacheData>(key, value);
        }

        /// <summary>
        /// 异步设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task SetAsync<TCacheData>(this ICache cache, TCacheData value, int expireSeconds = 1, CancellationToken token = default)
          where TCacheData : class, ICacheItem
        {
            var key = GetKey<TCacheData>(value);
            await cache.SetAsync<TCacheData>(key, value, expireSeconds, token);
        }
    }
}
