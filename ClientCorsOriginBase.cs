using System;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 客户端跨域配置
    /// </summary>
    [DisplayName("客户端跨域配置")]
    public class ClientCorsOrigin : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        [DisplayName("域名")]
        public string Origin { get; set; }

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
