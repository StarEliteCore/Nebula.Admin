using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class MenuOutPageListDto : OutputDto<Guid>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DisplayName("菜单名称")]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 组件地址(前端)
        /// </summary>
        [DisplayName("组件地址(前端)")]
        public string RouterPath { get; set; }

        /// <summary>
        /// 父级菜单ID
        /// </summary>
        [DisplayName("父级菜单ID")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]
        public Guid Iocn { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        [DisplayName("深度")]
        public int Depth { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public List<MenuOutPageListDto> Children { get; set; } = new List<MenuOutPageListDto>();
    }
}