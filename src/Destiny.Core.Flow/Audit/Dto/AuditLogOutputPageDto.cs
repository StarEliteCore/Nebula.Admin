using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Audit.Dto
{
    /// <summary>
    /// 审计日志分页输出Dto
    /// </summary>
    [DisplayName("审计日志分页列表")]
    public class AuditLogOutputPageDto : OutputDto<ObjectId>
    {

        public string BrowserInformation { get; set; }

        public string Ip { get; set; }


        public string FunctionName { get; set; }


        public string Action { get; set; }

        public double ExecutionDuration { get; set; }


        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        /// <summary>
        ///获取或设置 创建时间
        /// </summary>
        [DisplayName("审计时间")]
        public DateTime CreatedTime { get; set; }

        [DisplayName("用户名")]
        /// <summary>
        /// 获取或设置 操作用户名
        /// </summary>
        public string UserName { get; set; }


        /// </summary>
        public string NickName { get; set; }


        public AjaxResultType? OperationType { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }
    }
}