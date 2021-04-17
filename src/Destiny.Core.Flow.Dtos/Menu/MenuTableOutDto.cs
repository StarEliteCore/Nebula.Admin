using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{
    /// <summary> 菜单表格 </summary
    [AutoMapping(typeof(MenuEntity))]
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
        public string Path { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        [DisplayName("深度")]
        public int Depth { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("当前菜单以上所有的父级")]
        public string ParentNumber { get; set; }

        /// <summary>
        /// 组件地址
        /// </summary>
        [DisplayName("组件地址")]
        public string Component { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public MenuEnum Type { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<MenuTableOutDto> children { get; set; } = new List<MenuTableOutDto>();

        /// <summary>
        /// 模板页
        /// </summary>
        [DisplayName("模板页")]
        public string Layout { get; set; }


        /// <summary>
        /// 是否隐藏
        /// </summary>
        [DisplayName("是否隐藏")]
        public bool IsHide { get; set; }

        /// <summary>
        /// 事件名
        /// </summary>
        [DisplayName("事件名")]
        public string EventName { get; set; }
    }
}