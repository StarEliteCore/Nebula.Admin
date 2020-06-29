using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Destiny.Core.Flow.Security.Jwt
{
    /// <summary>
    /// JWT结果
    /// </summary>
    public class JwtResult
    {

        public string AccessToken { get; set; }


        public long AccessExpires { get; set; }

        public Claim[] claims { get; set; } = new Claim[]{ };

    }
}
