

using DestinyCore.EntityFrameworkCore;
using DestinyCore.Extensions;
using DestinyCore.Options;
using EntityFrameworkCore.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.Startups
{
    public class EntityFrameworkCoreModule_Tests : EntityFrameworkCoreModuleBase
    {
        protected override IServiceCollection AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            var settings = services.GetObjectOrNull<AppOptionSettings>();
            var connection = settings.DbContexts.Values.First().ConnectionString;
            services.AddDestinyDbContext<TestContext001>(x =>
            {
                x.ConnectionString = connection;//settings.DbContexts.Values.First().ConnectionString;
                x.DatabaseType = settings.DbContexts.Values.First().DatabaseType;
                x.MigrationsAssemblyName = "Destiny.Core.AspNetMvc.Test";
            });
            services.AddUnitOfWork<TestContext001>();
            return services;
        }
    }


}
