using Destiny.Core.Flow.Filter.Abstract;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
    /// <summary>
    /// 分页集合Dto扩展
    /// </summary>
    public static class PageListExtensions
    {
        /// <summary>
        /// 分页集合Dto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageResult"></param>
        /// <returns></returns>
        public static PageList<T> ToPageList<T>(this IPagedResult<T> pageResult)
        {
            var result = pageResult;
            return new PageList<T>() { ItemList = result.ItemList, Message = result.Message, Total = result.Total, Success = result.Success };
        }
    }
}