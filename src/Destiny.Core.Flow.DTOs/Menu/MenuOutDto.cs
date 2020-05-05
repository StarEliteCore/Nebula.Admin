using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class MenuOutDto : OutputDto<Guid>
    {
        /// <summary>
        /// 菜单标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 是否展开直子节点
        /// </summary>
        public bool expand { get; set; } = true;
        /// <summary>
        /// 禁掉响应
        /// </summary>
        public string disabled { get; set; }
        /// <summary>
        /// 菜单深度
        /// </summary>
        public string Depth { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// 当前节点以上所有组织架构
        /// </summary>
        public string ParenNumber { get; set; }


        public List<MenuOutDto> children { get; set; } = new List<MenuOutDto>();
    }
}
