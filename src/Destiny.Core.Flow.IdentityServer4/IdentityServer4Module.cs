using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IdentityServer.Store;
using Destiny.Core.Flow.IdentityServer.Validation;
using Destiny.Core.Flow.Modules;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.Flow.IdentityServer
{
    public class IdentityServer4Module : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var issuerUri = service.GetConfiguration()["AuthServer:Authority"];
            var build = service.AddIdentityServer(opt =>
             {
                 opt.Events.RaiseErrorEvents = true;
                 opt.Events.RaiseInformationEvents = true;
                 opt.Events.RaiseFailureEvents = true;
                 opt.Events.RaiseSuccessEvents = true;
                 //opt.IssuerUri = issuerUri;
             })
                .AddDeveloperSigningCredential()
            .AddProfileService<DestinyProfileService>();
            service.AddTransient<IClientStore, ClientStoreBase>();
            service.AddTransient<IResourceStore, ApiResourceStoreBase>();
            service.AddTransient<IPersistedGrantStore, PersistedGrantStoreBase>();
            service.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordBaseValidator>();
        }

        public override void ApplicationInitialization(ApplicationContext context)
        {
            //var app = context.GetApplicationBuilder();
            //app.UseStaticFiles();

        }


    }
}
