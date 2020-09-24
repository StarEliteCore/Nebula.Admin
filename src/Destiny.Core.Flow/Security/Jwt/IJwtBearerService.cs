using Destiny.Core.Flow.Dependency;
using System;

namespace Destiny.Core.Flow.Security.Jwt
{
    /// <summary>
    /// JwtBearer服务
    /// </summary>
    public interface IJwtBearerService: IScopedDependency
    {
        JwtResult CreateToken(Guid userId, string userName);
    }
}
