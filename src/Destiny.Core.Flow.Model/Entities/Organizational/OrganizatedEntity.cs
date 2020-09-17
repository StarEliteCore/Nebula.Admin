using Destiny.Core.Flow.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Model.Entities.Organizational
{
    [DisplayName("组织架构")]
    public class OrganizatedEntity : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        /// <summary>
        /// 父级Id
        /// </summary>
        [DisplayName("父级Id")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 组织架构名称
        /// </summary>
        [DisplayName("组织架构名称")]
        public string Name { get; set; }

        /// <summary>
        /// 部门领导
        /// </summary>
        [DisplayName("部门领导")]
        public Guid LadingCadre { get; set; }

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
        /// 获取或设置 最后修改用户
        /// </summary>
        [DisplayName("最后修改用户")]
        public virtual Guid? LastModifierUserId { get; set; }

        /// <summary>
        /// 获取或设置 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public virtual DateTime? LastModifionTime { get; set; }

        /// <summary>
        ///获取或设置 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        ///获取或设置 创建用户ID
        /// </summary>
        [DisplayName("创建用户ID")]
        public virtual Guid? CreatorUserId { get; set; }

        /// <summary>
        ///获取或设置 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public virtual DateTime CreatedTime { get; set; }

        /// <summary>
        ///获取或设置 描述
        /// </summary>
        [DisplayName("描述")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 第一负责人
        /// </summary>
        [DisplayName("第一负责人")]
        public virtual Guid? FirstLeader { get; set; }

        /// <summary>
        /// 第二负责人
        /// </summary>

        [DisplayName("第二负责人")]
        public virtual Guid? SecondLeader { get; set; }
    }
}