using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Audit.Dto
{
    /// <summary>
    /// 审计实体
    /// </summary>
    public class AuditEntryBaseDto
    {

        /// <summary>
        /// 实体名称
        /// </summary>
        [DisplayName("实体名称")]
        public string EntityName { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        [DisplayName("实体显示名称")]
        public string DisplayName { get; set; }


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


        public virtual string TypeName { get; set; }


    }

    public class AuditEntryDto: AuditEntryBaseDto
    {

        public AuditEntryDto()
        {
            AuditPropertys = new List<AuditPropertyDto>();
        }
        public List<AuditPropertyDto> AuditPropertys { get; set; }


    }



}
