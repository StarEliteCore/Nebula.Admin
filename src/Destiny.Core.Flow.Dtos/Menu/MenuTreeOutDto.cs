using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class MenuTreeOutDto : OutputDto<Guid>
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
        /// 是否展开直子节点
        /// </summary>
        public Guid Key { get; set; }

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

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool @checked { get; set; } = false;

        [DisplayName("类型")]
        public MenuEnum Type { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<MenuTreeOutDto> children { get; set; } = new List<MenuTreeOutDto>();
    }
}