using Destiny.Core.Flow.Data;
using Destiny.Core.Flow.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Audit
{
    [DisplayName("审计日志属性")]
    [MongoDBTable("DestinyAuditPropertyEntry")]
    public class AuditPropertysEntry : EntityBase<ObjectId>
    {
        public AuditPropertysEntry()
        {
            Id = ObjectId.GenerateNewId();
        }

        /// <summary>
        /// 属性名称
        /// </summary>
        [DisplayName("属性名称")]
        public string Properties { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        [DisplayName("属性显示名称")]
        public string PropertieDisplayName { get; set; }

        /// <summary>
        /// 修改前数据
        /// </summary>
        [DisplayName("修改前数据")]
        public string OriginalValues { get; set; }

        /// <summary>
        /// 修改后数据
        /// </summary>
        [DisplayName("修改后数据")]
        public string NewValues { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        [DisplayName("属性类型")]
        public string PropertiesType { get; set; }

        /// <summary>
        /// 审计日志实体Id
        /// </summary>
        [DisplayName("审计日志实体Id")]
        public ObjectId AuditEntryId { get; set; }
    }
}