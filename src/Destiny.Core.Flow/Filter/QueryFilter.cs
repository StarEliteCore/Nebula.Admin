using Destiny.Core.Flow.Enums;
using System.Collections.Generic;

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
    }
}
