using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Destiny.Core.Flow.Filter
{
    public static class CollectionPropertySorter<T>
    {
        private static readonly ConcurrentDictionary<string, LambdaExpression> Cache = new ConcurrentDictionary<string, LambdaExpression>();

        /// <summary>
        /// 按指定的属性名称对<see cref="IQueryable{T}"/>序列进行排序
        /// </summary>
        /// <param name="source">IQueryable{T}序列</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy(IQueryable<T> source, string propertyName, SortDirection sortDirection)
        {
            propertyName.NotNullOrEmpty("propertyName");
            dynamic keySelector = GetKeySelector(propertyName);
            return sortDirection == SortDirection.Ascending
                ? Queryable.OrderBy(source, keySelector)
                : Queryable.OrderByDescending(source, keySelector);
        }


        /// <summary>
        /// 按指定的属性名称对<se cref="IOrderedQueryable{T}"/>序列进行排序
        /// </summary>
        /// <param name="source">IOrderedQueryable{T}序列</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy(IOrderedQueryable<T> source, string propertyName, SortDirection sortDirection)
        {
            propertyName.NotNullOrEmpty("propertyName");
            dynamic keySelector = GetKeySelector(propertyName);
            return sortDirection == SortDirection.Ascending
                ? Queryable.ThenBy(source, keySelector)
                : Queryable.ThenByDescending(source, keySelector);
        }



        private static LambdaExpression GetKeySelector(string keyName)
        {
            Type type = typeof(T);
            string key = $"{type.FullName}.{keyName}";
            if (Cache.ContainsKey(key))
            {
                return Cache[key];
            }
            ParameterExpression param = Expression.Parameter(type);
            string[] propertyNames = keyName.Split(".");
            Expression propertyAccess = param;

            foreach (var propertyName in propertyNames)
            {
                PropertyInfo property = type.GetProperty(propertyName);
                if (property.IsNull())
                {
                    throw new Exception($"查找类似 指定对象中不存在名称为“{propertyName}”的属性");
                }
                type = property.PropertyType;
                propertyAccess = Expression.Property(propertyAccess, property);
            }
            LambdaExpression keySelector = Expression.Lambda(propertyAccess, param);
            Cache[key] = keySelector;
            return keySelector;
        }
    }
}
