using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Metadata.Builders
{
    
    public   class MongoDBFilterBuilder
    {


        public static Func<FilterOperator, Expression, Expression, Expression> GetOperateExpression = (operate, member, expression) => {

            switch (operate)
            {
                case FilterOperator.Equal:
                    return Expression.Equal(member, expression);

                case FilterOperator.NotEqual:
                    return Expression.NotEqual(member, expression);

                case FilterOperator.GreaterThan:
                    return Expression.GreaterThan(member, expression);

                case FilterOperator.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, expression);

                case FilterOperator.LessThan:
                    return Expression.LessThan(member, expression);

                case FilterOperator.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, expression);

                case FilterOperator.Like:
                    return Contains((member as MemberExpression), expression as ConstantExpression);
                default:
                    throw new AppException($"此{operate}过滤条件不支持！！");

            }


        };

        /// <summary>
        /// 得到表达式目录树
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="queryFilter">查询过滤</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetExpression<T>(QueryFilter queryFilter)
        {
            queryFilter.NotNull("queryFilter");
            ParameterExpression param = Expression.Parameter(typeof(T), "m");

            Expression expression = GetExpressionBody(param, queryFilter);
            return Expression.Lambda<Func<T, bool>>(expression, param);
        }

        private static Expression GetExpressionBody(ParameterExpression param, QueryFilter queryFilter)
        {

            List<Expression> expressions = new List<Expression>();
            Expression expression = Expression.Constant(true);
            if (queryFilter is null || (queryFilter?.Conditions.Count() == 0 && queryFilter?.Filters.Count() == 0)) //为空
            {
                return expression;
            }
            foreach (var item in queryFilter.Conditions)
            {
                expressions.Add(GetExpressionBody(param, item));
            }
            foreach (var item in queryFilter.Filters)
            {
                expressions.Add(GetExpressionBody(param, item));
            }

            if (queryFilter.FilterConnect == FilterConnect.And)
            {
                return expressions.Aggregate(Expression.AndAlso);
            }
            else
            {
                return expressions.Aggregate(Expression.OrElse);
            }
        }

        private static Expression GetExpressionBody(ParameterExpression param, FilterCondition filter)
        {

            var lambda = GetPropertyLambdaExpression(param, filter);
            var constant = ChangeTypeToExpression(filter, lambda.Body.Type);

            return GetOperateExpression(filter.Operator, lambda.Body, constant);

        }


        /// <summary>
        /// 得到值
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>

        private static Expression ChangeTypeToExpression(FilterCondition filter, Type conversionType)
        {
            var constant = Expression.Constant(true);

            if (conversionType.Name != typeof(string).Name&&filter.Operator==FilterOperator.Like)
            {

                throw new AppException("此{conversionType.Name}类型不支持Like,只有{typeof(string).Name}才支持Like！！！");
            }

            var value = filter.Value.AsTo(conversionType);
            if (value == null)
            {
                return constant;
            }

            return Expression.Constant(value, conversionType);
        }





        private static LambdaExpression GetPropertyLambdaExpression(ParameterExpression parameter, FilterCondition filter)
        {
            var type = parameter.Type;
            var property = type.GetProperty(filter.Field, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
            if (property == null)
            {
                throw new AppException($"没有得到{filter.Field}该名字!!!");
            }
            MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property);
            return Expression.Lambda(propertyAccess, parameter);
        }



        private static readonly MethodInfo stringContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });


        public static Expression Contains(MemberExpression member, ConstantExpression constant1)
        {
            Expression constant = constant1.TrimToLower();

            return Expression.Call(member.TrimToLower(), stringContainsMethod, constant);
                 
        }


    }
}
