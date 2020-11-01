using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using MongoDB.Driver;

namespace Destiny.Core.Flow
{
    public static class FindFluentExtensions
    {

        public static IOrderedFindFluent<TEntity, TEntity> OrderBy<TEntity>(this IFindFluent<TEntity, TEntity> findFluent, OrderCondition[] orderConditions)
        {
            IOrderedFindFluent<TEntity, TEntity> orderFindFluent = null;
            if (orderConditions == null || orderConditions.Length == 0)
            {
                orderFindFluent = FindFluentSortBy<TEntity, TEntity>.OrderBy(findFluent, "Id", Destiny.Core.Flow.Enums.SortDirection.Ascending);
            }
            orderConditions.ForEach((e, i) =>
            {
                orderFindFluent = i == 0 ? FindFluentSortBy<TEntity, TEntity>.OrderBy(findFluent, e.SortField, e.SortDirection) :
                FindFluentSortBy<TEntity, TEntity>.ThenBy(orderFindFluent, e.SortField, e.SortDirection);
            });

            return orderFindFluent;

        }
    }
}
