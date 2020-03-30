using Destiny.Core.Flow.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    public class FilterInfo
    {

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 过滤操作器
        /// </summary>
        public FilterOperator Operator { get; set; } = FilterOperator.Equal;

        /// <summary>
        /// 过滤连接器
        /// </summary>
        public FilterConnect Connect { get; set; } = FilterConnect.And;
    }
}
