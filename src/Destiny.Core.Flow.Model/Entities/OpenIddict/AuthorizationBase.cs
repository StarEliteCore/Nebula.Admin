using DestinyCore.Entity;
using System;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Model.Entities.OpenIddict
{

    public abstract class AuthorizationBase<TKey> : AuthorizationBase<TKey, ApplicationBase<TKey>, AuthorizationBase<TKey>> where TKey : IEquatable<TKey>
    {

    }

    /// <summary>
    /// 验证
    /// </summary>
    /// <typeparam name="TKey">id类型</typeparam>
    public abstract class AuthorizationBase<TKey, TApplication, TAuthorization> : EntityBase<TKey>, ICreatedTime
        where TKey : IEquatable<TKey>
        where TApplication: class
        where TAuthorization: class
    {
        /// <summary>
        /// 关联验证
        /// </summary>
        public virtual TAuthorization Authorization { get; set; }
        /// <summary>
        /// 关联应用
        /// </summary>
        public virtual TApplication Application { get; set; }

        /// <summary>
        /// 并发令牌
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 附加属性列表 序列化为json
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// 授权范围列表 序列化为json
        /// </summary>
        public virtual string Scopes { get; set; }

        /// <summary>
        /// 状态  未激活(inactive) 已赎回(redeemed) 拒绝(rejected) 废除(revoked) 可用(valid)
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// 所属用户
        /// </summary>
        public virtual string Subject { get; set; }

        /// <summary>
        /// token列表 
        /// </summary>
        public virtual ICollection<TokenBase<TKey>> Tokens { get; } = new HashSet<TokenBase<TKey>>();

        /// <summary>
        /// 验证类型 临时(ad-hoc) 永久(permanent)
        /// </summary>
        public virtual string Type { get; set; }
    }
}
