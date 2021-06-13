using DestinyCore.Entity;
using OpenIddict.EntityFrameworkCore.Models;
using System;

namespace Destiny.Core.Flow.OpenIddict.Entities
{
    public class OpenIddictScope : OpenIddictEntityFrameworkCoreScope<Guid>, IEntity<Guid>
    {
    }
}
