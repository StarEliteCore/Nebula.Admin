
using Destiny.Core.Flow.OpenIddict.Entities;
using DestinyCore.EntityFrameworkCore;
using DestinyCore.Extensions;
using DestinyCore.Modules;
using DestinyCore.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.EntityFrameworkCore.Models;
using System;
using System.Linq;

namespace Destiny.Core.Flow.OpenIddict.EntityFrameworkCore
{


    public class OpenIddictEntityFrameworkCoreModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                    .UseDbContext<OpenIddictEntityDefaultDbContext>()
                    .ReplaceDefaultEntities<OpenIddictApplication, OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, Guid>();
                });

            //var settings = context.Services.GetObjectOrNull<AppOptionSettings>();
            //var connection = settings.DbContexts.Values.First().ConnectionString;
            //var provider = context.Services.BuildServiceProvider();
            context.Services.AddDbContext<OpenIddictEntityDefaultDbContext>(x =>
            {
                x.UseOpenIddict<OpenIddictApplication, OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, Guid>();
            });
            context.Services.AddUnitOfWork<OpenIddictEntityDefaultDbContext>();
        }
    }
}
