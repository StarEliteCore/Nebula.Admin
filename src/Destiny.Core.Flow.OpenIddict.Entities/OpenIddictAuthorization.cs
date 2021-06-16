using DestinyCore.Entity;
using OpenIddict.EntityFrameworkCore.Models;
using System;

namespace Destiny.Core.Flow.OpenIddict.Entities
{
    public class OpenIddictAuthorization : OpenIddictEntityFrameworkCoreAuthorization<Guid, OpenIddictApplication, OpenIddictToken>, IEntity<Guid> { }
}