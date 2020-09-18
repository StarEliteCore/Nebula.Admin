using Microsoft.Extensions.Internal;
using System;

namespace Destiny.Core.Flow.Exceptions
{
    /// <summary>
    /// 缺少类型注册异常
    /// </summary>

    public class MissingTypeRegistrationException : InvalidOperationException
    {
        public MissingTypeRegistrationException(Type serviceType)
            : base($"找不到类型的任何注册服务 '{TypeNameHelper.GetTypeDisplayName(serviceType)}'.")
        {
            ServiceType = serviceType;
        }

        public Type ServiceType { get; }
    }
}
