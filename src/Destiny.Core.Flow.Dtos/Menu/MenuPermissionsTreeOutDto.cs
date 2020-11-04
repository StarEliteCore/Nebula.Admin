using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{
    /// <summary>
    /// 菜单树形
    /// </summary>
    [DisplayName("菜单树形")]
    public class MenuPermissionsTreeOutDto : OutputDto<Guid>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DisplayName("路由名称")]
        public string Path { get; set; }

        /// <summary>
        /// 重定向
        /// </summary>
        [DisplayName("重定向")]
        public string Redirect { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Access { get; set; }

        /// <summary>
        /// 路由名称(前端)
        /// </summary>
        [DisplayName("路由名称")]
        public string Name { get; set; }

        /// <summary>
        /// 组件地址(前端)
        /// </summary>
        [DisplayName("组件名称")]
        public string Component { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 父级菜单ID
        /// </summary>
        [DisplayName("父级菜单ID")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 父级菜单ID
        /// </summary>
        [DisplayName("子级")]
        public List<MenuPermissionsTreeOutDto> Routes { get; set; } = new List<MenuPermissionsTreeOutDto>();
    }
}