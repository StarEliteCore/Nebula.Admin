using Destiny.Core.Flow.Data;
using Destiny.Core.Flow.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Model.Entities.Function
{
    [DisplayName("功能")]
    public class Function : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        public Function()
        {
            Id = ComnGuid.NewGuid();
        }

        [DisplayName("功能名字")]
        /// <summary>
        /// 功能名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [DisplayName("创建者")]
        public Guid? CreatorUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 最后修改者
        /// </summary>
        [DisplayName("最后修改者")]
        public Guid? LastModifierUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModifionTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [DisplayName("是否可用")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 链接Url
        /// </summary>
        [DisplayName("链接Url")]
        public string LinkUrl { get; set; }
    }
}