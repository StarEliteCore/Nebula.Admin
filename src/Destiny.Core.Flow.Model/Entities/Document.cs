using System;
using System.Collections.Generic;
using System.ComponentModel;
using DestinyCore.Entity;
namespace Destiny.Core.Flow.Entities
{

    /// <summary>
    /// 文档
    /// </summary>
    [DisplayName("文档")]
    public partial class Document : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        /// <summary>
        /// 获取或设置 内容
        /// </summary>
        [DisplayName("内容")]
        public string Content { get; set; }
        /// <summary>
        /// 获取或设置 文档类型ID
        /// </summary>
        [DisplayName("文档类型ID")]
        public Guid DocumentTypeId { get; set; }
        /// <summary>
        /// 获取或设置 标题
        /// </summary>
        [DisplayName("标题")]
        public string Title { get; set; }
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
