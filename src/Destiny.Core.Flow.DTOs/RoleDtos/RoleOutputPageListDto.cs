using AutoMapper;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Dtos.RoleDtos
{
    [AutoMap(typeof(Role))]
    public class RoleOutputPageListDto : IOutputDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称")]
        public string Name { get; set; }
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [DisplayName("标准化角色名称")]
        public string NormalizedName { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        [DisplayName("是否管理员")]
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }
        /// <summary>
        ///获取或设置 编码
        /// </summary>
        [DisplayName("编码")]
        public virtual string Code { get; set; }
        /// <summary>
        /// 版本标识
        /// </summary>
        [DisplayName("版本标识")]
        public string ConcurrencyStamp { get; set; }
    }
}
