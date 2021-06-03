using System;
using System.Collections.Generic;
using System.ComponentModel;
using DestinyCore.Entity;
namespace Destiny.Core.Flow.Entities
{

    /// <summary>
    /// 文档类型
    /// </summary>
    [DisplayName("文档类型")]
    public partial class DocumentType : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        /// <summary>
        /// 获取或设置 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 排序
        /// </summary>
        [DisplayName("排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 获取或设置 父级
        /// </summary>
        [DisplayName("父级")]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 获取或设置 描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }
        /// <summary>
        /// 获取或设置最后修改用户
        /// </summary>
        [DisplayName("最后修改用户")]
        public Guid? LastModifierUserId { get; set; }
        /// <summary>
        /// 获取或设置最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModifionTime { get; set; }
        /// <summary>
        /// 获取或设置是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 获取或设置创建用户ID
        /// </summary>
        [DisplayName("创建用户ID")]
        public Guid? CreatorUserId { get; set; }
        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

    }
}
