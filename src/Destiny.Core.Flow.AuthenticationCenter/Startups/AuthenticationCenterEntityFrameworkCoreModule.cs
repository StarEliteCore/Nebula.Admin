using DestinyCore.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.EntityFrameworkCore;
using DestinyCore.EntityFrameworkCore;
using DestinyCore.Modules;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{

    public class AuthenticationCenterEntityFrameworkCoreModule :AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddDestinyDbContext<IdentityServer4DefaultDbContext>();
            context.Services.AddUnitOfWork<IdentityServer4DefaultDbContext>();
            ServiceExtensions.AddRepository(context.Services);
        }
        //protected override IServiceCollection AddDestinyDbContextWnitUnitOfWork(IServiceCollection services)
        //{
        //    services.AddDestinyDbContext<IdentityServer4DefaultDbContext>();
        //    services.AddUnitOfWork<IdentityServer4DefaultDbContext>();
        //    return services;
        //}
     
    }
}
