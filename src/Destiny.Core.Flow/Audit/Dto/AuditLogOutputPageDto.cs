using Destiny.Core.Flow.Entity;
using MongoDB.Bson;
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
        ///获取或设置 创建用户ID
        /// </summary>
        [DisplayName("创建用户ID")]
        public Guid? CreatorUserId { get; set; }

        /// <summary>
        ///获取或设置 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        [DisplayName("用户名")]
        /// <summary>
        /// 获取或设置 操作用户名
        /// </summary>
        public string UserName { get; set; }

        [DisplayName("昵称")]
        /// <summary>
        /// 获取或设置 操作昵称
        /// </summary>
        public string NickName { get; set; }
    }
}