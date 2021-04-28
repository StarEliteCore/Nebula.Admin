using Destiny.Core.Flow.Filter.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    /// <summary>
    /// 页面查询参数
    /// </summary>
    public class QueryParameters : IFilteredRequest
    {
        public QueryFilter Filter { get; set; }
    }
}
