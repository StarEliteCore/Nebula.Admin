using System;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 客户端授权类型
    /// </summary>
    [DisplayName("客户端授权类型")]
    public class ClientGrantType : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 授权类型
        /// </summary>
        [DisplayName("授权类型")]
        public string GrantType { get; set; }

        /// <summary>
        /// 客户端id
        /// </summary>
        [DisplayName("客户端id")]
        public int ClientId { get; set; }

        /// <summary>
        /// 所属客户端
        /// </summary>
        [DisplayName("所属客户端")]
        public Client Client { get; set; }
    }
}