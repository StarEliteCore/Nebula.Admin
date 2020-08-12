using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Audit
{
    [DisplayName("审计日志")]
    [MongoDBTable("SuktAuditLog")]
    public class AuditEntry : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        /// <summary>
        /// 执行方法名
        /// </summary>
        [DisplayName("执行方法名")]
        public string Action { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        [DisplayName("功能名称")]
        public string DescriptionName { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        [DisplayName("表名称")]
        public string TableName { get; set; }
        /// <summary>
        /// 修改前数据
        /// </summary>
        [DisplayName("修改前数据")]
        public Dictionary<string, object> OriginalValues { get; set; }
        /// <summary>
        /// 修改后数据
        /// </summary>
        [DisplayName("修改后数据")]
        public Dictionary<string, object> NewValues { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        public Dictionary<string, object> KeyValues { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public DataOperationType OperationType { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        [DisplayName("属性名称")]
        public Dictionary<string, object> Properties { get; set; }
        /// <summary>
        ///  获取或设置 最后修改用户
        /// </summary>
        [DisplayName("最后修改用户")]
        public virtual Guid? LastModifierUserId { get; set; }
        /// <summary>
        /// 获取或设置 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public virtual DateTime? LastModifierTime { get; set; }
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
