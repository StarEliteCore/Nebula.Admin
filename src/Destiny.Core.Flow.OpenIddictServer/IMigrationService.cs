using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.OpenIddict.EntityFrameworkCore;
using DestinyCore.Dependency;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using System;
using System.Threading.Tasks;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Destiny.Core.Flow.OpenIddictServer
{
    public interface IMigrationService
    {
        Task EnsureMigrationAsync();
    }

    public class MigrationService : IMigrationService, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task EnsureMigrationAsync()
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<OpenIddictEntityDefaultDbContext>();
            //var uIContext = scope.ServiceProvider.GetRequiredService<OpenIddictUIContext>();

            await context.Database.MigrateAsync();
            //await uIContext.Database.MigrateAsync();

            await RegisterApplicationsAsync(scope.ServiceProvider);
            await RegisterScopesAsync(scope.ServiceProvider);

            await EnsureAdministratorRole(scope.ServiceProvider);
            await EnsureAdministratorUser(scope.ServiceProvider);

            static async Task RegisterApplicationsAsync(IServiceProvider provider)
            {
                var manager = provider.GetRequiredService<IOpenIddictApplicationManager>();

                if (await manager.FindByClientIdAsync("spa_client") is null)
                {
                    await manager.CreateAsync(new OpenIddictApplicationDescriptor
                    {
                        ClientId = "spa_client",
                        // ClientSecret = "901564A5-E7FE-42CB-B10D-61EF6A8F3654",
                        ConsentType = ConsentTypes.Explicit,
                        DisplayName = "SPA Client Application",
                        PostLogoutRedirectUris =
            {
              new Uri("https://localhost:5000"),
              new Uri("http://localhost:4200")
            },
                        RedirectUris =
            {
              new Uri("https://localhost:5000"),
              new Uri("http://localhost:4200")
            },
                        Permissions =
            {
              Permissions.Endpoints.Authorization,
              Permissions.Endpoints.Logout,
              Permissions.Endpoints.Token,
              Permissions.GrantTypes.AuthorizationCode,
              Permissions.GrantTypes.RefreshToken,
              Permissions.ResponseTypes.Code,
              Permissions.Scopes.Email,
              Permissions.Scopes.Profile,
              Permissions.Scopes.Roles,
              Permissions.Prefixes.Scope + "server_scope",
              Permissions.Prefixes.Scope + "api_scope"
            },
                        Requirements =
            {
              Requirements.Features.ProofKeyForCodeExchange
            }
                    });
                }

                if (await manager.FindByClientIdAsync("api_service") == null)
                {
                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = "api_service",
                        DisplayName = "API Service",
                        ClientSecret = "my-api-secret",
                        Permissions =
            {
              Permissions.Endpoints.Introspection
            }
                    };

                    await manager.CreateAsync(descriptor);
                }
            }

            static async Task RegisterScopesAsync(IServiceProvider provider)
            {
                var manager = provider.GetRequiredService<IOpenIddictScopeManager>();

                if (await manager.FindByNameAsync("server_scope") is null)
                {
                    await manager.CreateAsync(new OpenIddictScopeDescriptor
                    {
                        Name = "server_scope",
                        DisplayName = "Server scope access",
                        Resources =
            {
              "server"
            }
                    });
                }

                if (await manager.FindByNameAsync("api_scope") == null)
                {
                    var descriptor = new OpenIddictScopeDescriptor
                    {
                        Name = "api_scope",
                        DisplayName = "API Scope access",
                        Resources =
            {
              "api_service"
            }
                    };

                    await manager.CreateAsync(descriptor);
                }
            }

            static async Task EnsureAdministratorRole(IServiceProvider provider)
            {
                var manager = provider.GetRequiredService<RoleManager<IdentityRole>>();

                var role = "admin";
                var roleExists = await manager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    var newRole = new IdentityRole(role);
                    await manager.CreateAsync(newRole);
                }
            }

            static async Task EnsureAdministratorUser(IServiceProvider provider)
            {
                var manager = provider.GetRequiredService<UserManager<User>>();

                var user = await manager.FindByNameAsync("admin");
                if (user != null) return;

                var applicationUser = new User
                {
                    UserName = "admin",
                    Email = "admin@qq.com"
                };

                var userResult = await manager.CreateAsync(applicationUser, "Pass123$");
                if (!userResult.Succeeded) return;

                await manager.SetLockoutEnabledAsync(applicationUser, false);
                await manager.AddToRoleAsync(applicationUser, "role");
            }
        }
    }
}
