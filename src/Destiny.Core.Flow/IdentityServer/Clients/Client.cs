using System;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer
{
    public class Client : IdentityServer4.Models.Client, IEntity<Guid>
    {
        public Guid Id { get; protected set; }
    }
}
