using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Audit
{
    /// <summary>
    /// 审计
    /// </summary>
    public class AuditChangeBase
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



        [DisplayName("结果类型")]

        /// <summary>
        /// 结果类型
        /// </summary>
        public AjaxResultType ResultType { get; set; }

        public string UserId { get; set; }


        public string Message { get; set; }


    }


    public class AuditChange: AuditChangeBase
    {
        public AuditChange()
        {
            AuditEntitys = new List<AuditEntryDto>();
        }
        /// <summary>
        /// 审计实体集合
        /// </summary>

        public List<AuditEntryDto> AuditEntitys { get; set; }
        public DateTime StartTime { get; set; }
    }
}
