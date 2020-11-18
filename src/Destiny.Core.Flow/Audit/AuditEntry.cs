using Destiny.Core.Flow.Data;
using Destiny.Core.Flow.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Audit
{
    [DisplayName("审计日志实体")]
    [MongoDBTable("DestinyAuditEntityLog")]
    public class AuditEntry : EntityBase<ObjectId>
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



        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]


        public virtual DateTime CreatedTime { get; set; }


        public ObjectId AuditLogId { get; set; }

        public string UserId { get; set; }

        public string NickName { get; set; }

        public string UserName { get; set; }

        public virtual string LastModifionTime { get; set; }
    }
}