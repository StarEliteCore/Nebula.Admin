using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Destiny.Core.Flow.ExpressionUtil
{
    public static partial class Extensions
    {

        private static readonly MethodInfo trimMethod = typeof(string).GetMethod("Trim", new Type[0]);
        private static readonly MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", new Type[0]);

        /// <summary>
        ///获取特定属性的成员表达式
        /// </summary>
        /// <param name="param"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static MemberExpression GetMemberExpression(this ParameterExpression param, string propertyName)
        {
            return GetMemberExpression((Expression)param, propertyName);
        }

        private static MemberExpression GetMemberExpression(Expression param, string propertyName)
        {
            if (!propertyName.Contains("."))
            {
                return Expression.PropertyOrField(param, propertyName);
            }

            var index = propertyName.IndexOf(".");
            var subParam = Expression.PropertyOrField(param, propertyName.Substring(0, index));
            return GetMemberExpression(subParam, propertyName.Substring(index + 1));
        }

        /// <summary>
        /// 将string Trim和ToLower方法应用于ExpressionMember。
        /// </summary>
        /// <param name="member">将对其应用to方法的成员。</param>
        /// <returns></returns>
        public static Expression TrimToLower(this MemberExpression member)
        {
            var trimMemberCall = Expression.Call(member, trimMethod);
            return Expression.Call(trimMemberCall, toLowerMethod);
        }

        /// <summary>
        /// 将string Trim和ToLower方法应用于ExpressionMember。
        /// </summary>
        /// <param name="constant">将应用到方法的常数.</param>
        /// <returns></returns>
        public static Expression TrimToLower(this ConstantExpression constant)
        {
            var trimMemberCall = Expression.Call(constant, trimMethod);
            return Expression.Call(trimMemberCall, toLowerMethod);
        }

        /// <summary>
        /// 将“空检查”添加到表达式（在原始表达式之前）。
        /// </summary>
        /// <param name="expression">将挂起空检查的表达式。</param>
        /// <param name="member">将被检查的成员。</param>
        /// <returns></returns>
        public static Expression AddNullCheck(this Expression expression, MemberExpression member)
        {
            Expression memberIsNotNull = Expression.NotEqual(member, Expression.Constant(null));
            return Expression.AndAlso(memberIsNotNull, expression);
        }


    }
}
