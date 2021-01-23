using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
    public class UserClaimDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public string Type { get; set; }
    }
}
