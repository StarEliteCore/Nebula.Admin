using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.IdentityServer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4
{
    /// <summary>
    /// 身份资源
    /// </summary>
    [DisplayName("身份资源")]
    [DisableAuditing]
    public class IdentityResource : IdentityResourceBase, IFullAuditedEntity<Guid>
    {

        #region 公共属性
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
        #endregion
        /// <summary>
        /// 用户声明
        /// </summary>
        [Description("用户声明")]
        public List<IdentityResourceClaim> UserClaims { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        [Description("属性")]
        public List<IdentityResourceProperty> Properties { get; set; }
    }
}
