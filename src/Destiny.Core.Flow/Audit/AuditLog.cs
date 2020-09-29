using Destiny.Core.Flow.Entity;
using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Audit
{
    /// <summary>
    /// 日志主表
    /// </summary>
    [DisplayName("日志主表")]
    [MongoDBTable("DestinyAuditLog")]//
    public class AuditLog : EntityBase<ObjectId>, IFullAuditedEntity<Guid>
    {
        public AuditLog()
        {
            Id = ObjectId.GenerateNewId();
        }

        /// <summary>
        /// 浏览器信息
        /// </summary>
        [DisplayName("浏览器信息")]
        public string BrowserInformation { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [DisplayName("IP地址")]
        public string Ip { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        [DisplayName("功能名称")]
        public string FunctionName { get; set; }

        /// <summary>
        /// 操作Action
        /// </summary>
        [DisplayName("操作Action")]
        public string Action { get; set; }

        /// <summary>
        /// 执行时长
        /// </summary>
        [DisplayName("执行时长")]
        public double ExecutionDuration { get; set; }

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
    }
}