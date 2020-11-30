using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Filter
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="T">动态类型</typeparam>
    public class PageResult<T> : ResultBase, IPagedResult<T>, IHasResultType<AjaxResultType>
    {

        public PageResult() : this(new T[0], 0, "查询成功", true)
        {

        }
        public PageResult(IReadOnlyList<T> itemList, int total, string message = "查询成功", bool success = true)
        {
            ItemList = itemList;
            Total = total;
            Success = success;
            this.Message = message;
            Type = success ? AjaxResultType.Success : AjaxResultType.Error;
        }


        /// <summary>
        /// 总数
        /// </summary>

        public int Total { get; set; }

        public IReadOnlyList<T> ItemList { get; set; }
        public AjaxResultType Type { get; set; }
    }
}
