using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Audit
{
    /// <summary>
    /// 日志主表
    /// </summary>
    [DisplayName("日志主表")]
    [MongoDBTable("DestinyAuditLog")]//
    public class AuditLog : EntityBase<ObjectId>
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

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]


        [DisplayName("审计时间")]
        public virtual DateTime CreatedTime { get; set; }

        public AjaxResultType? OperationType { get; set; }

        public string UserId { get; set; }

        public  string Message { get; set; }

        [DisplayName("用户名")]
        /// <summary>
        /// 获取或设置 操作用户名
        /// </summary>
        public string UserName { get; set; }


        /// </summary>
        public string NickName { get; set; }
    }
}