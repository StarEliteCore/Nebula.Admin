using Destiny.Core.Flow.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.MenuFunction
{
    /// <summary>
    /// 菜单功能分页请求参数
    /// </summary>
    public class MenuFunctionPageRequestDto : PageRequest
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public Guid MenuId { get; set; }
    }
}
