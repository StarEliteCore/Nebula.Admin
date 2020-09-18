using System;

namespace Destiny.Core.Flow.Permission
{
    /// <summary>
    /// 在API配置此特性代表不需要验证接口权限
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class NoAuthorityVerificationAttribute : Attribute
    {

    }
}
