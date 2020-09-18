namespace Destiny.Core.Flow.Filter.Abstract
{
    /// <summary>
    /// 分页请求口
    /// </summary>
    public interface IPagedRequest
    {

        /// <summary>
        /// 当前页数
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 排序条件集合
        /// </summary>
        OrderCondition[] OrderConditions { get; set; }
    }
}
