using Destiny.Core.Flow.Filter.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    public class PagedRequestModel : IFilteredPagedRequest
    {

        public PagedRequestModel() {

            OrderConditions = new OrderCondition[] { };
            Filters = new FilterInfo[] { };
        }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public OrderCondition[] OrderConditions { get; set; }
        public FilterInfo[] Filters { get; set; }
    }
}
