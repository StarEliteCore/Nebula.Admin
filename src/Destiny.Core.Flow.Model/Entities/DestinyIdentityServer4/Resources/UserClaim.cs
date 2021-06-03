using System;
using System.ComponentModel;
using DestinyCore.Audit;
using DestinyCore.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 用户声明
    /// </summary>
    [DisplayName("用户声明")]
    [DisableAuditing]
    public abstract class UserClaim : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public string Type { get; set; }
    }
}