using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 客户端限制提供器
    /// </summary>
    public class ClientIdPRestriction : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 提供器
        /// </summary>
        public string Provider { get; set; }

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
