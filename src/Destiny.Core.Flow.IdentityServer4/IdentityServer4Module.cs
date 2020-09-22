using Destiny.Core.Flow.IdentityServer.Store;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.IdentityServer
{
    public class IdentityServer4Module : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var build= service.AddIdentityServer(opt =>
            {
                opt.Events.RaiseErrorEvents = true;
                opt.Events.RaiseInformationEvents = true;
                opt.Events.RaiseFailureEvents = true;
                opt.Events.RaiseSuccessEvents = true;
            }).AddClientStore<ClientStoreBase>()
            .AddResourceStore<ApiResourceStoreBase>()
            .AddPersistedGrantStore<PersistedGrantStoreBase>();
            build.AddDeveloperSigningCredential();
        }
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseIdentityServer();
        }

        
    }
}
