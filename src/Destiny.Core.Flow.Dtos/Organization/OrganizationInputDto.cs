using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Organizational;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Organization
{
    [AutoMapping(typeof(OrganizatedEntity))]
    [DisplayName("组织架构传入Dto")]
    public class OrganizationInputDto : InputDto<Guid>
    {
        /// <summary>
        /// 父级Id
        /// </summary>
        [DisplayName("父级Id")]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 组织架构名称
        /// </summary>
        [DisplayName("组织架构名称")]
        public string Name { get; set; }

        /// <summary>
        /// 部门领导
        /// </summary>
        [DisplayName("部门领导")]
        public Guid? LadingCadre { get; set; }

        /// <summary>
        /// 当前部门所有的父级
        /// </summary>
        [DisplayName("当前部门所有的父级")]
        public string ParentNumber { get; set; }

        /// <summary>
        /// 当前部门深度
        /// </summary>
        [DisplayName("当前部门深度")]
        public int Depth { get; set; }

        /// <summary>
        /// 第一负责人
        /// </summary>
        [DisplayName("第一负责人")]
        public Guid? FirstLeader { get; set; }

        /// <summary>
        /// 第二负责人
        /// </summary>

        [DisplayName("第二负责人")]
        public Guid? SecondLeader { get; set; }
    }
}