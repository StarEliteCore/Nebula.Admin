using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Stores;
using Destiny.Core.Flow.IdentityServer.Store;

namespace Destiny.Core.Flow.IdentityServer
{
    public static class IdentityServerExtension
    {
        //public static IIdentityServerBuilder AddDestinyIdentityServer(this IIdentityServerBuilder builder)
        //{
        //    //builder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();
        //    //builder.Services.AddTransient<IDeviceFlowStore, DeviceFlowStore>();
        //    return builder.AddClientStore<ClientStoreBase>()
        //        .AddResourceStore<ApiResourceStoreBase>()
        //        .AddPersistedGrantStore<PersistedGrantStoreBase>();
        //}
    }
}
