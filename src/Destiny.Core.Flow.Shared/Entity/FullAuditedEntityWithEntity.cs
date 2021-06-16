using DestinyCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Shared.Entity
{
    /// <summary>
    /// 全部审计实体与实体
    /// </summary>
    public class FullAuditedEntityWithEntity<IAuditedEntityKey, IEntityKey> : EntityBase<IEntityKey>, IFullAuditedEntity<IAuditedEntityKey>
        where IEntityKey : IEquatable<IEntityKey>
        where IAuditedEntityKey : struct
    {
        /// <summary>
        /// 获取或设置最后修改用户
        /// </summary>
        [DisplayName("最后修改用户")]
        public IAuditedEntityKey? LastModifierUserId { get; set; }

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
        public IAuditedEntityKey? CreatorUserId { get; set; }
        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }
    }
}
