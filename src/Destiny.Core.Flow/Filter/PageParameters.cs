using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    /// <summary>
    /// 分页所需的参数
    /// </summary>
    public class PageParameters
    {


        public PageParameters() : this(1, 10)
        {

        }

        public PageParameters(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderConditions = new Filter.OrderCondition[] { };
        }


        /// <summary>
        /// 分页索引
        /// </summary>

        public virtual int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public virtual int PageSize { get; set; }

        /// <summary>
        /// 排序条件集合
        /// </summary>
        public OrderCondition[] OrderConditions { get; set; }
    }
}
