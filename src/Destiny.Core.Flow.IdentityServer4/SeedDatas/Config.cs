using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer
{
    public class Config
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
                new ApiResource("Destiny.Core.Flow.API", "Mosi.OA.API") {
                    // include the following using claims in access token (in addition to subject id)
                    //requires using using IdentityModel;
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Role },
                    ApiSecrets = new List<Secret>()
                    {
                        new Secret("api_secret".Sha256())
                    },
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

                    RedirectUris =           { "http://localhost:8080/LoginedCallbackView" },
                    PostLogoutRedirectUris = { "http://localhost:8080" },
                    AllowedCorsOrigins =     { "http://localhost:8080" },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "Destiny.Core.Flow.API"
                    },
                }
            };
        }


    }
}
