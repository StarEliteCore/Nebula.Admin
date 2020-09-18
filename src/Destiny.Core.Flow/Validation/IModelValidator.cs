using System;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Validation
{

    public interface IModelValidator<in TModel> : IModelValidator
    {

        IEnumerable<ValidationFailure> Validate(TModel model);
    }
    /// <summary>
    /// 模型验证器
    /// </summary>
    public interface IModelValidator
    {
        /// <summary>
        /// 同步验证指定的实例
        /// 包含验证逻辑和业务规则验证
        /// </summary>
        /// <param name="model">要验证的模型</param>
        /// <returns>

        /// </returns>
        IEnumerable<ValidationFailure> Validate(object model);

        bool CanValidateInstancesOfType(Type type);
    }
}
