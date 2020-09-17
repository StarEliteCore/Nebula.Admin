using Destiny.Core.Flow.Identity;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow
{
    public abstract class IdentityModuleBase<TUserStore, TRoleStore, TUser, TUserRole, TRole, TUserKey, TRoleKey> : AppModule
          where TUserStore : class, IUserStore<TUser>
          where TRoleStore : class, IRoleStore<TRole>
          where TUser : UserBase<TUserKey>
          where TUserRole : UserRoleBase<TUserKey, TRoleKey>
          where TRole : RoleBase<TRoleKey>
          where TUserKey : IEquatable<TUserKey>
          where TRoleKey : IEquatable<TRoleKey>
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddScoped<IUserStore<TUser>, TUserStore>();

            context.Services.AddScoped<IRoleStore<TRole>, TRoleStore>();
            Action<IdentityOptions> identityOption = IdentityOption();
            var identityBuilder = context.Services.AddIdentity<TUser, TRole>(identityOption);

            context.Services.AddSingleton<IdentityErrorDescriber>(new IdentityErrorDescriberZhHans());
            UseIdentityBuilder(identityBuilder);
            AddAuthentication(context.Services);
        }

        protected abstract Action<IdentityOptions> IdentityOption();

        protected abstract void AddAuthentication(IServiceCollection services);

        protected abstract IdentityBuilder UseIdentityBuilder(IdentityBuilder identityBuilder);
    }
}