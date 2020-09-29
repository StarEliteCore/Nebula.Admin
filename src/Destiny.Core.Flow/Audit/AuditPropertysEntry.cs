using Destiny.Core.Flow.Data;
using Destiny.Core.Flow.Entity;
using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Audit
{
    [DisplayName("审计日志属性")]
    [MongoDBTable("DestinyAuditPropertyEntry")]
    public class AuditPropertysEntry : EntityBase<ObjectId>, IFullAuditedEntity<Guid>
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

        #region 公共字段

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

        #endregion 公共字段
    }
}