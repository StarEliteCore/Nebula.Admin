namespace Destiny.Core.Flow.Filter.Abstract
{
    /// <summary>
    /// 过滤查询分页请求
    /// </summary>
    public interface IFilteredPagedRequest : IPagedRequest
    {

        /// <summary>
        /// 过滤查询
        /// </summary>
        QueryFilter Filter { get; set; }
    }
}
