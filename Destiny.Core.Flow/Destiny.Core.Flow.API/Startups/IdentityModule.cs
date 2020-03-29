using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Model.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    public class IdentityModule : IdentityModuleBase<UserStore, RoleStore, User, UserRole, Role, Guid, Guid>
    {

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var services1 = base.ConfigureServices(services);


            return services1;
        }

        //public override ModuleLevel Level => ModuleLevel.Frame;
   
        public override void Configure(IApplicationBuilder app)
        {

           

        }

        protected override Action<IdentityOptions> IdentityOption()
        {
            return options =>
            {

                options.SignIn.RequireConfirmedEmail = false;

                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;



            };
        }

        protected override void AddAuthentication(IServiceCollection services)
        {
         
        }

        protected override IdentityBuilder UseIdentityBuilder(IdentityBuilder identityBuilder)
        {
            return identityBuilder.AddDefaultTokenProviders();
        }
    }
    
}
