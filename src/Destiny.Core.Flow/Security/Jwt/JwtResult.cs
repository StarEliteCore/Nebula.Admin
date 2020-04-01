using System;
using System.Collections.Generic;
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

    }
}
