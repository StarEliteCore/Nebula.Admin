using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Destiny.Core.Flow.Security.Jwt
{
    public class JwtBearerService : IJwtBearerService
    {
        private readonly IServiceProvider _provider = null;
        private readonly JwtOptions _jwtOptions = null;
        private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        public JwtBearerService(IServiceProvider provider)
        {
            _provider = provider;
            _jwtOptions = provider.GetAppSettings()?.Jwt;
        }

        /// <summary>
        /// 创建令牌
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public JwtResult CreateToken(Guid userId, string userName)
        {

            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, userName),
            };
            var (token, accessExpires) = this.BuildJwtToken(claims, _jwtOptions);

            return new JwtResult()
            {
                AccessToken = token,
                AccessExpires = accessExpires.UnixTicks().AsTo<long>(),
                claims = claims,
            };
        }

        public (string, DateTime) BuildJwtToken(Claim[] claims, JwtOptions options)
        {

            options.NotNull(nameof(options));
            claims.NotNull(nameof(claims));
            if (options.SecretKey.IsNullOrEmpty())
            {
                throw new AppException("密钥不能为空!!");
            }
            DateTime now = DateTime.UtcNow;
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            double minutes = options.ExpireMins <= 0 ? 5 : options.ExpireMins;

            DateTime expires = now.AddMinutes(minutes);


            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = options.Audience ?? "Destiny",
                Issuer = options.Issuer ?? "Destiny",
                SigningCredentials = credentials,
                NotBefore = now,
                IssuedAt = now,
                Expires = expires
            };


            SecurityToken token = _tokenHandler.CreateToken(descriptor);
            return (_tokenHandler.WriteToken(token), expires);
        }
    }
}
