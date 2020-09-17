using Destiny.Core.Flow.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Permissions
{
    public class RolePermissionOutputDto : IOutputDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称")]
        public string Name { get; set; }

        ///获取或设置 描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }
    }
}