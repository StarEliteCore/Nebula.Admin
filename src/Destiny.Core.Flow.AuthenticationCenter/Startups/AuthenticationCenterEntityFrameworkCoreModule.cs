using Destiny.Core.Flow.AuthenticationCenter.DbContexts;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{

    public class AuthenticationCenterEntityFrameworkCoreModule : EntityFrameworkCoreModule
    {


        protected override IServiceCollection AddDestinyDbContextWnitUnitOfWork(IServiceCollection services)
        {
            services.AddDestinyDbContext<IdentityServer4DefaultDbContext>();
            services.AddUnitOfWork<IdentityServer4DefaultDbContext>();
            return services;
        }
     
    }
}
