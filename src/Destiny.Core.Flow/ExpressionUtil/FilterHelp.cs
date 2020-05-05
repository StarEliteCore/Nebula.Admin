using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

using Destiny.Core.Flow.Helpers;
using Microsoft.EntityFrameworkCore.DynamicLinq;

namespace Destiny.Core.Flow.ExpressionUtil
{
    /// <summary>
    /// 查询帮助
    /// </summary>
   public static class FilterHelp
    {
        /// <summary>
        /// 得到表达目录树
        /// </summary>
        /// <typeparam name="T">动态实体</typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetExpression<T>(FilterInfo[] filters)
        {
            if (filters == null || filters.Length == 0)
            {
                Expression<Func<T, bool>> expression = t=> true;
                return expression;
            }

            if (filters.Any(o => o.Operator == FilterOperator.In))
            {
                throw new AppException("没有实现In查询方式!!");
            }             
            string expressionStr = GetFilterExpression(filters);

            var expression1 =  DynamicExpressionParser.ParseLambda<T, bool>(ParsingConfig.Default,true, expressionStr, filters.Select(o => o.Value).ToArray());
            return expression1;
        }


        public static Expression<Func<T, bool>> GetExpression<T>(string filterJson)
        {

            if (!filterJson.IsNullOrEmpty() || filterJson == "[]")
            {
                Expression<Func<T, bool>> expression = t => true;
                return expression;
            }
            var filters=  filterJson.FromJson<FilterInfo[]>();

           return FilterHelp.GetExpression<T>(filters);

        }


        /// <summary>
        /// 得到查询信息拼接好字符串
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        private static string GetFilterExpression(FilterInfo[] filters)
        {
            StringBuilder strWhere = new StringBuilder();
            int count = 0;
            foreach (FilterInfo filterInfo in filters)
            {
                var index = count + 1;
                //"City == @0 and Orders.Count >= @1"
                //var index1 = filters.IndexOf(this);
                if (filterInfo.Operator == FilterOperator.Like)
                {
                    
                   
                    strWhere.Append($"{filterInfo.Key}.{filterInfo.Operator.ToDescription<FilterCodeAttribute>()}(@{count}) ");

                }
                else
                {
                    strWhere.Append($"{filterInfo.Key} {filterInfo.Operator.ToDescription<FilterCodeAttribute>()} ");
                }

                if (index != filters.Length)
                {
                    strWhere.Append($"{filterInfo.Connect.ToDescription<FilterCodeAttribute>()} ");
                }
             
               count++;
            }
            return strWhere?.ToString();
        }
    }
}
