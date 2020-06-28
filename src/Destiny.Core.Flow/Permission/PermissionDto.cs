using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Permission
{
    /// <summary>
    /// 必要参数类，
    /// 继承 IAuthorizationRequirement，用于设计自定义权限处理器PermissionHandler
    /// 因为AuthorizationHandler 中的泛型参数 TRequirement 必须继承 IAuthorizationRequirement
    /// </summary>
    public class PermissionDto: IAuthorizationRequirement
    {
        public PermissionDto(string deniedAction, string claimType, string loginPath, string issuer, string audience, TimeSpan expiration, SigningCredentials signingCredentials)
        {
            DeniedAction = deniedAction;
            ClaimType = claimType;
            LoginPath = loginPath;
            Issuer = issuer;
            Audience = audience;
            Expiration = expiration;
            SigningCredentials = signingCredentials;
        }

        /// <summary>
        /// 无权限action
        /// </summary>
        public string DeniedAction { get; set; }

        /// <summary>
        /// 认证授权类型
        /// </summary>
        public string ClaimType { internal get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        public string LoginPath { get; set; } = "/Api/Login";
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 订阅人
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan Expiration { get; set; }
        /// <summary>
        /// 签名验证
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
        /// <summary>
        /// 用户权限集合
        /// </summary>
        public List<string> PermissionsUrl { get; set; } = new List<string>();
    }
}
