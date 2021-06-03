using DestinyCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
    public class ApiScopePropertyDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}
