using Destiny.Core.Flow.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Model.Entities.Rolemenu
{
    [DisplayName("角色菜单")] //为什么要实体？？？？？？？后缀Entity，全部用软删除
    public class RoleMenuEntity : EntityBase<Guid>
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [DisplayName("角色ID")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        [DisplayName("菜单ID")]
        public Guid MenuId { get; set; }
    }
}