using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 客户机密
    /// </summary>
    [DisplayName("客户机密")]
    public class ClientSecretBase: SecretBase<Guid>
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public Guid ClientId { get; set; }

    }
}
