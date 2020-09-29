using Destiny.Core.Flow.Data;
using Destiny.Core.Flow.Entity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Audit
{
    [DisplayName("审计日志实体")]
    [MongoDBTable("DestinyAuditEntityLog")]
    public class AuditEntry : EntityBase<ObjectId>, IFullAuditedEntity<Guid>
    {
        public AuditEntry()
        {
            Id = ObjectId.GenerateNewId();
        }

        /// <summary>
        /// 实体名称
        /// </summary>
        [DisplayName("实体名称")]
        public string EntityAllName { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        [DisplayName("实体显示名称")]
        public string EntityDisplayName { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        [DisplayName("表名称")]
        public string TableName { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        public Dictionary<string, object> KeyValues { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 操作类型
        /// </summary>
        [DisplayName("操作类型")]
        public DataOperationType OperationType { get; set; }

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
        /// 审计日志主表Id
        /// </summary>
        [DisplayName("审计日志主表Id")]
        public ObjectId AuditLogId { get; set; }
    }
}