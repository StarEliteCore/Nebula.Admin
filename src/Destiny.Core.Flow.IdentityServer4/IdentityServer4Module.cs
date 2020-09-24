using Destiny.Core.Flow.IdentityServer.Service.Account;
using Destiny.Core.Flow.IdentityServer.Service.Consent;
using Destiny.Core.Flow.IdentityServer.Store;
using Destiny.Core.Flow.IdentityServer.Validation;
using Destiny.Core.Flow.Modules;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
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
            var build = service.AddIdentityServer(opt =>
             {
                 opt.Events.RaiseErrorEvents = true;
                 opt.Events.RaiseInformationEvents = true;
                 opt.Events.RaiseFailureEvents = true;
                 opt.Events.RaiseSuccessEvents = true;
             }).AddDeveloperSigningCredential();
            service.AddTransient<IClientStore, ClientStoreBase>();
            service.AddTransient<IResourceStore, ApiResourceStoreBase>();
            service.AddTransient<IPersistedGrantStore, PersistedGrantStoreBase>();
            //service.AddTransient<IClientSecretValidator, ClientSecretBaseValidator>();
            service.AddTransient<IAccountService, AccountService>();
            service.AddTransient<IConsentService, ConsentService>();

        }
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseStaticFiles();
        }

        
    }
}
