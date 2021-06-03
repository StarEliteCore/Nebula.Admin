using DestinyCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
    public class ApiScopeClaimDto : IDto<Guid>
    {
        public Guid Id { get; set; }


    }
}
