using DestinyCore.Modules;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Destiny.Core.Flow.OpenIddict
{
    public class OpenIddictModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = Claims.Role;
            });

            context.Services.AddOpenIddict()
                .AddServer(options =>
                {
                    options.SetIssuer(new System.Uri("https://localhost:5001/"));
                    //注册端点
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                                   .SetDeviceEndpointUris("/connect/device")
                                   .SetLogoutEndpointUris("/connect/logout")
                                   .SetTokenEndpointUris("/connect/token")
                                   .SetIntrospectionEndpointUris("/connect/introspect")
                                   .SetUserinfoEndpointUris("/connect/userinfo")
                                   .SetVerificationEndpointUris("/connect/verify");

                    //启用验证码 隐式 客户端凭证 设备码 密码 刷新token模式
                    options.AllowAuthorizationCodeFlow()
                           .AllowImplicitFlow()
                           .AllowClientCredentialsFlow()
                           .AllowDeviceCodeFlow()
                           .AllowPasswordFlow()
                           .AllowRefreshTokenFlow();

                    //注册授权范围
                    options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles, Scopes.OfflineAccess, Scopes.OpenId, Scopes.Phone, "demo_api");

                    //注册登录和加密证书
                    options.AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate();

                    //强制客户端使用PKCE Proof Key for Code Exchange
                    options.RequireProofKeyForCodeExchange();

                    options.UseAspNetCore()//注册aspnet core host
                           .EnableStatusCodePagesIntegration()//启用状态码页面集成
                           .EnableAuthorizationEndpointPassthrough()
                           .EnableLogoutEndpointPassthrough()
                           .EnableTokenEndpointPassthrough()
                           .EnableUserinfoEndpointPassthrough()
                           .EnableVerificationEndpointPassthrough()
                           .DisableTransportSecurityRequirement();//开发环境可禁用必须传ssl
                })
                .AddValidation(options =>
                {
                    //TODO: 从配置读取列表
                    options.AddAudiences("AuthServer");//Audience需要和创建scope时的Resources一致
                    options.UseLocalServer();//从本地server示例导入验证配置
                    options.UseAspNetCore();//启用aspnet core host
                });
                
        }
    }
}
