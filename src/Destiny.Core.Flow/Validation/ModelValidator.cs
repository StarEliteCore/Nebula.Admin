using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Destiny.Core.Flow.Validation
{
    public abstract class ModelValidator<TModel> : IModelValidator<TModel>
    {
        IEnumerable<ValidationFailure> IModelValidator.Validate(object model)
        {

            model.NotNull(nameof(model));
            if (!((IModelValidator)this).CanValidateInstancesOfType(model.GetType()))
            {
                throw new InvalidOperationException(
                    $"无法验证类型的实例 '{model.GetType().GetTypeInfo().Name}'. 此验证器只能验证类型为 '{typeof(TModel).Name}'.");
            }

            return Validate((TModel)model);
        }

        bool IModelValidator.CanValidateInstancesOfType(Type type)
        {
            return typeof(TModel).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
        }

        public abstract IEnumerable<ValidationFailure> Validate(TModel model);
    }
}
