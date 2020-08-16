using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Destiny.Core.Flow.Extensions
{
    public static partial class Extensions
    {
        public static Expression<Func<TEntity, bool>> ToEqualityExpression<TEntity, TKey>(this TKey id)
         where TEntity : IEntity<TKey>
         where TKey : IEquatable<TKey>
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, nameof(IEntity<TKey>.Id)),
                Expression.Constant(id, typeof(TKey))
            );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}
