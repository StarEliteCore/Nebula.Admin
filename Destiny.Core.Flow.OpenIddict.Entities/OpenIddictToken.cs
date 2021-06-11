using DestinyCore.Entity;
using OpenIddict.EntityFrameworkCore.Models;
using System;

namespace Destiny.Core.Flow.OpenIddict.Entities
{
    public class OpenIddictToken : OpenIddictEntityFrameworkCoreToken<Guid, OpenIddictApplication, OpenIddictAuthorization>, IEntity<Guid> { }
}