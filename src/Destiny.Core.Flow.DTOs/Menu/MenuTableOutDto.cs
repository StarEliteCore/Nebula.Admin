using Destiny.Core.Flow.Entity;
using System;

namespace Destiny.Core.Flow.Dtos.Menu
{
    /// <summary>
    /// 菜单表格
    /// </summary>
    public class MenuTableOutDto : OutputDto<Guid>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级菜单ID
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 组件地址(前端)
        /// </summary>
        public int RouterPath { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public Guid Iocn { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
    }
}