using System;

namespace Destiny.Core.Flow.Dtos.MenuFunction
{
    /// <summary>
    /// 菜单功能分页DTO
    /// </summary>
    public class MenuFunctionOutPageListDto
    {
        /// <summary>
        /// 功能ID
        /// </summary>
        public Guid FunctionId { get; set; }

      
        /// <summary>
        /// 功能名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}