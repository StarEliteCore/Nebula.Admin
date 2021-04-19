using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Destiny.Core.Flow.Filter
{
    public class QueryFilter
    {
        public QueryFilter()
        {

        }
        public QueryFilter(FilterConnect filterConnect, List<FilterCondition> conditions)
        {
            this.FilterConnect = filterConnect;
            this.Conditions = conditions;
        }
        /// <summary>
        /// 查询条件and或者Or
        /// </summary>
        public FilterConnect FilterConnect { get; set; } = FilterConnect.And;

        public List<QueryFilter> Filters = new List<QueryFilter>();
        public List<FilterCondition> Conditions { get; set; } = new List<FilterCondition>();


        /// <summary>
        /// 添加条件
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="value">值</param>
        /// <param name="operator">操作条件</param>

        public QueryFilter AddCondition(string field,object value, FilterOperator @operator=FilterOperator.Equal) {

            field.NotNullOrEmpty(nameof(field));
            @operator.NotNull(nameof(@operator));
            this.Conditions.Add(new FilterCondition(field, value, @operator));
            return this;
        }
    }
}
