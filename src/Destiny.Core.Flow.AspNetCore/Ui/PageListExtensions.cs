
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Ui;


using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
    /// <summary>
    ///  分页集合Dto扩展
    /// </summary>
    public static class PageListExtensions
    {
        /// <summary>
        /// 分页集合Dto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageResult"></param>
        /// <returns></returns>
        public static PageList<T> PageList<T>(this PageResult<T> pageResult)
        {
            var result = pageResult;
            return new PageList<T>() { Data= result.Data,Message= result.Message,Total= result.Total,Success= result.Success};
        }
    }
}
