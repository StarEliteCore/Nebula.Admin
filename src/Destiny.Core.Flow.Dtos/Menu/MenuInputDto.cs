using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{
    [AutoMapping(typeof(MenuEntity))]
    public class MenuInputDto : InputDto<Guid>
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
        public string Path { get; set; }

        /// <summary>
        /// 父级菜单ID
        /// </summary>
        [DisplayName("父级菜单ID")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 组件地址
        /// </summary>
        [DisplayName("组件地址")]
        public string Component { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]
        public string Icon { get; set; }

        /// <summary>
        ///获取或设置 描述
        /// </summary>
        [DisplayName("描述")]
        public virtual string Description { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("当前菜单以上所有的父级")]
        public string ParentNumber { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        [DisplayName("深度")]
        public int Depth { get; set; }

        public List<Guid> FunctionId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public MenuEnum Type { get; set; }
    }
}