using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Destiny.Core.Flow
{
    public static class MongoCollectionExtensions
    {

        public static async Task<IPagedResult<TEntity>> ToPageAsync<TEntity>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> predicate, IPagedRequest request)
        {
            var count = !predicate.IsNotNull() ? await collection.CountDocumentsAsync(predicate) : await collection.CountDocumentsAsync(FilterDefinition<TEntity>.Empty);
            var findFluent = collection.Find(predicate).Skip(request.PageSize * (request.PageIndex - 1)).Limit(request.PageSize);

            findFluent = findFluent.OrderBy(request.OrderConditions);
            var lists = await findFluent.ToListAsync();
            return new PageResult<TEntity>() { ItemList = lists, Message = "加载成功", Success = true, Total = count.AsTo<int>() };

        }

        public static async Task<IPagedResult<TResult>> ToPageAsync<TEntity, TResult>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> predicate, IPagedRequest request, Expression<Func<TEntity, TResult>> selector)
        {
            var count = !predicate.IsNotNull() ? await collection.CountDocumentsAsync(predicate) : await collection.CountDocumentsAsync(FilterDefinition<TEntity>.Empty);
            var findFluent = collection.Find(predicate).Skip(request.PageSize * (request.PageIndex - 1)).Limit(request.PageSize);

            findFluent = findFluent.OrderBy(request.OrderConditions);
            var lists = await findFluent.Project(selector).ToListAsync();
            return new PageResult<TResult>() { ItemList = lists, Message = "加载成功", Success = true, Total = count.AsTo<int>() };

        }




    }
}
