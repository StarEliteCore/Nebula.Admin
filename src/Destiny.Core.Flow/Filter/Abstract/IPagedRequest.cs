namespace Destiny.Core.Flow.Filter.Abstract
{
    /// <summary>
    /// 分页请求口
    /// </summary>
    public interface IPagedRequest: IOrderRequest
    {

        /// <summary>
        /// 当前页数
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        int PageSize { get; set; }

    
    }
}
