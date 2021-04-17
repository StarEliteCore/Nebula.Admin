using Destiny.Core.Flow.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{
    /// <summary>
    /// 登录完成获取菜单列表
    /// </summary>
    public class MenuPermissionsOutDto : OutputDto<Guid>
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
    }
}