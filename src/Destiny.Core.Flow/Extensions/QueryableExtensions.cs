using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Extensions
{
    /// <summary>
    /// Queryable扩展
    /// </summary>
    public static partial class Extensions
    {


        /// <summary>
        /// 把排序条件集合转成排序查询
        /// </summary>
        /// <typeparam name="TEntity">要排序实体</typeparam>
        /// <param name="source">源</param>
        /// <param name="orderConditions">排序条件集合</param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, OrderCondition[] orderConditions)
        {
            IOrderedQueryable<TEntity> orderSource = null;
            if (orderConditions == null || orderConditions.Length == 0)
            {
                orderSource = CollectionPropertySorter<TEntity>.OrderBy(source, "Id", SortDirection.Ascending);
            }

            int count = 0;

            foreach (OrderCondition orderCondition in orderConditions)
            {
                orderSource = count == 0
                    ? CollectionPropertySorter<TEntity>.OrderBy(source, orderCondition.SortField, orderCondition.SortDirection)
                    : CollectionPropertySorter<TEntity>.ThenBy(orderSource, orderCondition.SortField, orderCondition.SortDirection);
                count++;
            }

            return orderSource;
        }


        /// <summary>
        /// 从集合中查询指定数据筛选的分页信息
        /// </summary>
        /// <typeparam name="TEntity">动态实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageParameters">分页参数</param>
        /// <returns></returns>
        public static async Task<PageResult<TEntity>> ToPageAsync<TEntity>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate, IPagedRequest request)

        {
            request.NotNull(nameof(request));

            var result = await source.WhereAsync(request.PageIndex, request.PageSize, predicate, request.OrderConditions);
            var list = await result.data.ToArrayAsync();
            var total = result.totalNumber;
            return new PageResult<TEntity>(list, total);

        }

        /// <summary>
        /// 从集合中查询指定数据筛选的分页信息
        /// </summary>
        /// <typeparam name="TEntity">动态实体类型</typeparam>
        /// <typeparam name="TResult">要返回动态实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageParameters">分页参数</param>
        /// <param name="selector">数据筛选表达式</param>
        /// <returns></returns>
        public static async Task<PageResult<TResult>> ToPageAsync<TEntity, TResult>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate, IPagedRequest request, Expression<Func<TEntity, TResult>> selector)
        {
            request.NotNull(nameof(request));
            selector.NotNull(nameof(selector));
            var result = await source.WhereAsync(request.PageIndex, request.PageSize, predicate, request.OrderConditions);
            var list = await result.data.Select(selector).ToArrayAsync();
            var total = result.totalNumber;
            return new PageResult<TResult>(list, total);
        }






        /// <summary>
        /// 从集合中查询指定数据筛选的分页信息
        /// </summary>
        /// <typeparam name="TEntity">动态实体类型</typeparam>
        /// <typeparam name="TResult">要返回动态实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageParameters">分页参数</param>
        /// <param name="selector">数据筛选表达式</param>
        /// <returns></returns>
        public static async Task<PageResult<TEntity>> ToPageAsync<TEntity>(this IQueryable<TEntity> source, IPagedRequest request)
        {
            request.NotNull(nameof(request));

            var result = await source.WhereAsync(request.PageIndex, request.PageSize, null, request.OrderConditions);
            var list = await result.data.ToArrayAsync();
            var total = result.totalNumber;
            return new PageResult<TEntity>(list, total);
        }

        /// <summary>
        /// 从集合中查询指定输出DTO的分页信息
        /// </summary>
        /// <typeparam name="TEntity">动态实体类型</typeparam>
        /// <typeparam name="TOutputDto">输出DTO数据类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageParameters">分页参数</param>
        /// <returns></returns>
        public static async Task<PageResult<TOutputDto>> ToPageAsync<TEntity, TOutputDto>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate, PageParameters pageParameters)
          where TOutputDto : IOutputDto
        {
            pageParameters.NotNull(nameof(pageParameters));
            var result = await source.WhereAsync(pageParameters.PageIndex, pageParameters.PageSize, predicate, pageParameters.OrderConditions);
            var list = await result.data.ToOutput<TOutputDto>().ToArrayAsync();
            var total = result.totalNumber;
            return new PageResult<TOutputDto>(list, total);
        }





        ///// <summary>
        ///// 从集合中查询指定输出DTO的分页信息
        ///// </summary>
        ///// <typeparam name="TEntity">动态实体类型</typeparam>
        ///// <typeparam name="TOutputDto">输出DTO数据类型</typeparam>
        ///// <param name="source">数据源</param>
        ///// <param name="pageParameters">分页参数</param>
        ///// <returns></returns>
        public static async Task<IPagedResult<TOutputDto>> ToPageAsync<TEntity, TOutputDto>(this IQueryable<TEntity> source, IPagedRequest request)
          where TOutputDto : IOutputDto
        {
            request.NotNull(nameof(request));
            var isFiltered = request is IFilteredPagedRequest;
            Expression<Func<TEntity, bool>> expression = null;
            if (isFiltered)
            {
                var filter = (request as IFilteredPagedRequest).Filter;
                expression = filter == null ? null : FilterBuilder.GetExpression<TEntity>(filter);
            }
            var result = await source.WhereAsync(request.PageIndex, request.PageSize, expression, request.OrderConditions);
            var list = await result.data.ToOutput<TOutputDto>().ToArrayAsync();
            var total = result.totalNumber;
            return new PageResult<TOutputDto>(list, total);

        }

        private static async Task<(IQueryable<TEntity> data, int totalNumber)> WhereAsync<TEntity>(this IQueryable<TEntity> source, int pageIndex,
              int pageSize, Expression<Func<TEntity, bool>> predicate, OrderCondition[] orderConditions)
        {
            var total = !predicate.IsNull() ? await source.CountAsync(predicate) : await source.CountAsync();
            if (!predicate.IsNull())
            {
                source = source.Where(predicate);
            }

            source = source.OrderBy(orderConditions);

            return (!source.IsNull() ? source.Skip(pageSize * (pageIndex - 1)).Take(pageSize) : Enumerable.Empty<TEntity>().AsQueryable(), total);
        }




        /// <summary>
        /// 动态查询
        /// </summary>
        /// <typeparam name="TEntity">要查询实体</typeparam>
        /// <param name="source">数据</param>
        /// <param name="queryFilter"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> source, QueryFilter queryFilter)
        {

            source.NotNull(nameof(source));
            queryFilter.NotNull(nameof(queryFilter));
            var expression = FilterBuilder.GetExpression<TEntity>(queryFilter);
            return source.Where(expression);
        }


        /// <summary>
        /// 从集合中查询指定数据筛选的树数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="rootwhere"></param>
        /// <param name="childswhere"></param>
        /// <param name="addchilds"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<TreeResult<TResult>> ToTreeResultAsync<TEntity, TResult>(this IQueryable<TEntity> source,
            Func<TResult, TResult, bool> rootwhere,
            Func<TResult, TResult, bool> childswhere, Action<TResult, IEnumerable<TResult>> addchilds, TResult entity = default(TResult))
        {

            rootwhere.NotNull(nameof(rootwhere));
            childswhere.NotNull(nameof(childswhere));
            addchilds.NotNull(nameof(addchilds));
            var list = await source.ToOutput<TResult>().ToListAsync();
            var treeData = list.ToTree(rootwhere, childswhere, addchilds, entity);
            return new TreeResult<TResult>
            {

                ItemList = treeData,
            };
        }

        public static string ToSql(this IQueryable query)
        {
            string relationalCommandCacheText = "_relationalCommandCache";
            string selectExpressionText = "_selectExpression";
            string querySqlGeneratorFactoryText = "_querySqlGeneratorFactory";
            string relationalQueryContextText = "_relationalQueryContext";

            string cannotGetText = "Cannot get";

            var enumerator = query.Provider.Execute<IEnumerable>(query.Expression).GetEnumerator();
            var relationalCommandCache = enumerator.Private(relationalCommandCacheText) as RelationalCommandCache;
            var queryContext = enumerator.Private<RelationalQueryContext>(relationalQueryContextText) ?? throw new InvalidOperationException($"{cannotGetText} {relationalQueryContextText}");
            var parameterValues = queryContext.ParameterValues;


            if (relationalCommandCache != null)
            {
                var command = relationalCommandCache.GetRelationalCommand(parameterValues);
                var parameterNames = new HashSet<string>(command.Parameters.Select(p => p.InvariantName));

                return $"{command.CommandText};{Environment.NewLine}";
            }
            else
            {
                SelectExpression selectExpression = enumerator.Private<SelectExpression>(selectExpressionText) ?? throw new InvalidOperationException($"{cannotGetText} {selectExpressionText}");
                IQuerySqlGeneratorFactory factory = enumerator.Private<IQuerySqlGeneratorFactory>(querySqlGeneratorFactoryText) ?? throw new InvalidOperationException($"{cannotGetText} {querySqlGeneratorFactoryText}");

                var sqlGenerator = factory.Create();
                var command = sqlGenerator.GetCommand(selectExpression);
                return $"{command.CommandText};{Environment.NewLine}";
            }
            return string.Empty;

        }

        private static readonly BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, bindingFlags)?.GetValue(obj);
        private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, bindingFlags)?.GetValue(obj);
    }
}
