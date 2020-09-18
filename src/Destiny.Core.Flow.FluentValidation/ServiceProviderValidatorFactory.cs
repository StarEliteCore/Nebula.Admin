using FluentValidation;
using System;

namespace Destiny.Core.Flow.FluentValidation
{
    /// <summary>
    /// 服务提供商验证程序工厂
    /// </summary>
    internal sealed class ServiceProviderValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProviderValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return _serviceProvider.GetService(validatorType) as IValidator;
        }
    }
}
