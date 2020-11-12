

using Destiny.Core.Flow.IdentityServer;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace Destiny.Core.Flow.IdentityServer
{
    public sealed class Config 
    {
        /// <summary>
        /// 资源授权类型
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "角色", new List<string> { JwtClaimTypes.Role }),
            };
        }
        /// <summary>
        /// API资源名称
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource() {
                    Name="Destiny.Core.Flow.API",
                    // include the following using claims in access token (in addition to subject id)
                    //requires using using IdentityModel;
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Role },
                    ApiSecrets = new List<Secret>()
                    {
                        new Secret("Destiny.Core.Flow.API_secret".Sha256())
                    },
                    Scopes =
                    {
                        "Destiny.Core.Flow.API"
                    }
                }
            };
        }
        // 客户端
        public static IEnumerable<Client> GetClients()
        {
            // javascript client
            return new List<Client> {
                new Client {
                    ClientId = "DestinyCoreFlowReactClient",
                    ClientName = "Destiny.Core.Flow.ReactClient",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris =           { "http://localhost:8848/callback","https://admin.destinycore.club/callback" },
                    PostLogoutRedirectUris = { "http://localhost:8848","https://admin.destinycore.club" },
                    AllowedCorsOrigins =     { "http://localhost:8848","https://admin.destinycore.club" },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "Destiny.Core.Flow.API"
                    },
                },
                new Client {
                    ClientId = "DestinyCoreFlowReactClientpwd",
                    ClientName = "Destiny.Core.Flow.ReactClientpwd",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris =           { "http://localhost:8080/LoginedCallbackView" },
                    PostLogoutRedirectUris = { "http://localhost:8080" },
                    AllowedCorsOrigins =     { "http://localhost:8080" },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "Destiny.Core.Flow.API"
                    },
                },
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope()
                {
                    Name = "Destiny.Core.Flow.API",
                    DisplayName = "Destiny.Core.Flow.API",
                }
            };
        }


    }
}
