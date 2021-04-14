using Destiny.Core.Flow.Data;
using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Model.Entities
{
    /// <summary>
    /// 文档类型
    /// </summary>
    [DisplayName("文档类型")]

    public class DocumentType : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {


        public DocumentType()
        {
            Id = ComnGuid.NewGuid();
        }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int Sort { get; set; }


        /// <summary>
        /// 父子
        /// </summary>
        [DisplayName("父子")]

        public Guid? ParentId { get; set; }

        /// <summary>
        ///获取或设置 描述
        /// </summary>
        [DisplayName("描述")]
        public virtual string Description { get; set; }


        public Guid? CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? LastModifionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
