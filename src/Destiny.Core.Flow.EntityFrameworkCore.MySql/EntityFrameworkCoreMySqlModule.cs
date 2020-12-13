using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.MySql
{
    /// <summary>
    /// MySql模块
    /// </summary>
    public class EntityFrameworkCoreMySqlModule : EntityFrameworkCoreModuleBase
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            base.ConfigureServices(context);
            context.Services.AddSingleton(typeof(IDbContextDrivenProvider), typeof(MySqlDbContextDrivenProvider));

        }

       
    }
}
