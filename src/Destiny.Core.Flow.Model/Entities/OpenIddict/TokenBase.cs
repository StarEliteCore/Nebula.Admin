using DestinyCore.Entity;
using System;

namespace Destiny.Core.Flow.Model.Entities.OpenIddict
{
    public abstract class TokenBase<TKey> : TokenBase<TKey, ApplicationBase<TKey>, AuthorizationBase<TKey>> where TKey : IEquatable<TKey>
    {

    }

    /// <summary>
    /// 令牌
    /// </summary>
    /// <typeparam name="TKey">id类型</typeparam>
    public abstract class TokenBase<TKey, TApplication, TAuthorization> : EntityBase<TKey>, ICreatedTime
        where TKey : IEquatable<TKey>
        where TApplication: class
        where TAuthorization: class
    {
        /// <summary>
        /// 关联应用
        /// </summary>
        public virtual TApplication Application { get; set; }

        /// <summary>
        /// 关联验证
        /// </summary>
        public virtual TAuthorization Authorization { get; set; }


        /// <summary>
        /// 并发令牌 用于乐观锁
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the UTC creation date of the current token.
        /// </summary>
        public virtual DateTime CreatedTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public virtual DateTime? ExpirationDate { get; set; }


        /// <summary>
        /// 负载
        /// </summary>
        public virtual string Payload { get; set; }

        /// <summary>
        /// 附加属性列表 序列化为json
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// 赎回时间
        /// </summary>
        public virtual DateTime? RedemptionDate { get; set; }

        /// <summary>
        /// 引用标识
        /// </summary>
        public virtual string ReferenceId { get; set; }

        /// <summary>
        /// 状态 未激活(inactive) 已赎回(redeemed) 拒绝(rejected) 废除(revoked) 可用(valid)
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// 所属用户
        /// </summary>
        public virtual string Subject { get; set; }

        /// <summary>
        /// token类型   访问令牌:access_token 授权码:authorization_code 设备码:device_code id令牌:IdToken  刷新令牌:refresh_token 用户码:user_code
        /// </summary>
        public virtual string Type { get; set; }
    }
}