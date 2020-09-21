using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.IdentityServer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4
{
    /// <summary>
    /// 客户端实体
    /// </summary>
    [DisplayName("客户端")]
    public class Client : ClientBase, IFullAuditedEntity<Guid>
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

        #region IdentityServer4原始导航属性

        public List<ClientClaim> Claims { get; set; }

        public List<ClientCorsOrigin> AllowedCorsOrigins { get; set; }

        public List<ClientProperty> Properties { get; set; }

        public List<ClientIdPRestriction> IdentityProviderRestrictions { get; set; }

        public List<ClientRedirectUri> RedirectUris { get; set; }

        public List<ClientPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }

        public List<ClientSecret> ClientSecrets { get; set; }

        public List<ClientScope> AllowedScopes { get; set; }

        public List<ClientGrantType> AllowedGrantTypes { get; set; }

        #endregion
    }
}
