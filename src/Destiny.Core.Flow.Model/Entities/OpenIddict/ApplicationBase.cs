using DestinyCore.Entity;
using System;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Model.Entities.OpenIddict
{
    public abstract class ApplicationBase<TKey> : ApplicationBase<TKey, AuthorizationBase<TKey>, TokenBase<TKey>> where TKey: IEquatable<TKey>
    {

    }

    /// <summary>
    /// 应用
    /// </summary>
    /// <typeparam name="TKey">id类型</typeparam>
    /// <typeparam name="TAuthorization">验证类型</typeparam>
    /// <typeparam name="TToken">令牌类型</typeparam>
    public abstract class ApplicationBase<TKey, TAuthorization, TToken> : EntityBase<TKey> 
        where TKey : IEquatable<TKey>
        where TAuthorization : class
        where TToken : class
    {
        /// <summary>
        /// 应用关联的验证列表
        /// </summary>
        public virtual ICollection<TAuthorization> Authorizations { get; } = new HashSet<TAuthorization>();

        /// <summary>
        /// 应用标识
        /// </summary>
        public virtual string ClientId { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        public virtual string ClientSecret { get; set; }

        /// <summary>
        /// 并发令牌  用于乐观锁
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 许可类型   分别为显式、隐式、系统、外部
        /// </summary>
        public virtual string ConsentType { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// 本地化显示名称列表  序列化为json 例如: {"en-US":"Application cliente MVC"}
        /// </summary>
        public virtual string DisplayNames { get; set; }

        /// <summary>
        /// 权限列表 序列化为json 例如: [""gt:password",,"scp:email","scp:profile"]
        /// </summary>
        public virtual string Permissions { get; set; }

        /// <summary>
        /// 退出回调uri列表 序列化为json 例如: ["https://localhost:44381/signout-oidc"]
        /// </summary>
        public virtual string PostLogoutRedirectUris { get; set; }

        /// <summary>
        /// 应用附加属性列表 序列化为json
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// 登录回调uri列表 序列化为json 例如: ["https://localhost:44381/signin-oidc"]
        /// </summary>
        public virtual string RedirectUris { get; set; }

        /// <summary>
        /// 所需条件列表 序列化为json
        /// </summary>
        public virtual string Requirements { get; set; }

        /// <summary>
        /// 关联token列表
        /// </summary>
        public virtual ICollection<TToken> Tokens { get; } = new HashSet<TToken>();

        /// <summary>
        /// 应用类型   分为秘密、公开
        /// </summary>
        public virtual string Type { get; set; }
    }
}
