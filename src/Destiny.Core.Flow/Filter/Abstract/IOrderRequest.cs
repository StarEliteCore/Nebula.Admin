using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter.Abstract
{
    /// <summary>
    /// 排序接口
    /// </summary>
    public interface IOrderRequest
    {
        /// <summary>
        /// 排序条件集合
        /// </summary>
        OrderCondition[] OrderConditions { get; set; }
    }
}
