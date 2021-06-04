﻿using DestinyCore.EntityFrameworkCore;
using DestinyCore.Events;
using DestinyCore.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EntityFrameworkCore
{
    [DependsOn(
      typeof(MediatorAppModule)

   )]
    public class EntityFrameworkCoreModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {

            context.Services.AddDestinyDbContext<DefaultDbContext>();
            context.Services.AddUnitOfWork<DefaultDbContext>();
            ServiceExtensions.AddRepository(context.Services);
           var DD= context.Services;
        }
    }
}
