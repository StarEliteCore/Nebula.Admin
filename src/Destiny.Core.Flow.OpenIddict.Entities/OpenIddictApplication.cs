
using OpenIddict.EntityFrameworkCore.Models;
using System;

namespace Destiny.Core.Flow.OpenIddict.Entities
{
    public class OpenIddictApplication : OpenIddictEntityFrameworkCoreApplication<Guid, OpenIddictAuthorization, OpenIddictToken>, DestinyCore.Entity.IEntity<Guid> { }
}
