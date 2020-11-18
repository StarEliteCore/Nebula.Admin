using AutoMapper;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Model.Entities.Menu;
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
    /// <summary>
    /// Vue动态路由树形
    /// </summary>
    [AutoMap(typeof(MenuEntity))]
    public class VueDynamicRouterTreeOutDto : OutputDto<Guid>
    {
        public VueDynamicRouterTreeOutDto()
        {
            Children = new List<VueDynamicRouterTreeOutDto>();
            ButtonChildren = new List<VueDynamicRouterTreeOutDto>();
        }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int Sort { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public MenuEnum Type { get; set; }
        /// <summary>
        /// 路由地址(前端)
        /// </summary>
        [DisplayName("路由地址(前端)")]
        public string Path { get; set; }
        /// <summary>
        /// 组件地址
        /// </summary>
        [DisplayName("组件地址")]
        public string Redirect { get; set; }
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
        /// 父级菜单ID
        /// </summary>
        [DisplayName("父级菜单ID")]
        public Guid ParentId { get; set; }
        /// <summary>
        /// 当前菜单以上所有的父级
        /// </summary>
        [DisplayName("当前菜单以上所有的父级")]
        public string ParentNumber { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DisplayName("菜单名称")]
        public string Name { get; set; }


        /// <summary>
        /// 事件名
        /// </summary>
        [DisplayName("事件名")]
        public string EventName { get; set; }
        /// <summary>
        /// 子级
        /// </summary>
        [DisplayName("菜单名称")]
        public List<VueDynamicRouterTreeOutDto> Children { get; set; }
        /// <summary>
        /// 按钮集合
        /// </summary>
        [DisplayName("按钮集合")]
        public List<VueDynamicRouterTreeOutDto> ButtonChildren { get; set; }


    }
}