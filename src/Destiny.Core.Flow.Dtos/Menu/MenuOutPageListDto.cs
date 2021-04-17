using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{
    [AutoMapping(typeof(MenuEntity))]
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
        public string Iocn { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        [DisplayName("深度")]
        public int Depth { get; set; }

        [DisplayName("类型")]
        public MenuEnum Type { get; set; }


        /// <summary>
        ///获取或设置 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public  DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModifionTime { get; set; }


        /// <summary>
        ///获取或设置 描述
        /// </summary>
        [DisplayName("描述")]
        public  string Description { get; set; }

        /// <summary>
        /// 菜单 
        /// </summary>
        ///可以单独出来，有没有办法做法公用的？？？？
        public List<MenuOutPageListDto> Children { get; set; } = new List<MenuOutPageListDto>();


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