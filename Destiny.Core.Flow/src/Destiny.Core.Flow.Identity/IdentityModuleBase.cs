using Destiny.Core.Flow.Identity;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{
    public abstract class IdentityModuleBase<TUserStore, TRoleStore, TUser, TUserRole, TRole, TUserKey, TRoleKey> :AppModuleBase
          where TUserStore : class, IUserStore<TUser>
          where TRoleStore : class, IRoleStore<TRole>
          where TUser : UserBase<TUserKey>
          where TUserRole : UserRoleBase<TUserKey, TRoleKey>
          where TRole : RoleBase<TRoleKey>
          where TUserKey : IEquatable<TUserKey>
          where TRoleKey : IEquatable<TRoleKey>
    {
 


        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserStore<TUser>, TUserStore>();

            services.AddScoped<IRoleStore<TRole>, TRoleStore>();
            Action<IdentityOptions> identityOption = IdentityOption();
            var identityBuilder = services.AddIdentity<TUser, TRole>(identityOption);

            services.AddSingleton<IdentityErrorDescriber>(new IdentityErrorDescriberZhHans());
            //UseIdentityBuilder(identityBuilder);
            //AddAuthentication(services);
            return services;
        }


        protected abstract Action<IdentityOptions> IdentityOption();


        protected abstract void AddAuthentication(IServiceCollection services);

        protected abstract IdentityBuilder UseIdentityBuilder(IdentityBuilder identityBuilder);

        public override void Configure(IApplicationBuilder app)
        {
            // app.UseAuthentication();
        }



    }
}
