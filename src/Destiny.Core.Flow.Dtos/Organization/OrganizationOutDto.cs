using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Dtos.Organization
{
    /// <summary>
    /// 组织架构OutDto
    /// </summary>

    public class OrganizationOutDto : OutputDto<Guid>
    {
        /// <summary>
        /// 组织架构标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 是否展开直子节点
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// 是否展开直子节点
        /// </summary>
        public bool Expand { get; set; }

        /// <summary>
        /// 禁掉响应
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 组织架构深度
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 当前节点以上所有组织架构
        /// </summary>
        public string ParenNumber { get; set; }

        /// <summary>
        /// 第一负责人
        /// </summary>
        public Guid? FirstLeader { get; set; }

        /// <summary>
        /// 第二负责人
        /// </summary>
        public Guid? SecondLeader { get; set; }

        /// <summary>
        /// 组织架构标题
        /// </summary>
        public List<OrganizationOutDto> children { get; set; } = new List<OrganizationOutDto>();
    }
}