using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Security.Jwt
{
    /// <summary>
    /// JwtBearer服务
    /// </summary>
    public interface IJwtBearerService
    {
        JwtResult CreateToken(Guid userId, string userName);
    }
}
