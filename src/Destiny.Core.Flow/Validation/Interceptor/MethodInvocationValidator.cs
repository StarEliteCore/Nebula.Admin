using Destiny.Core.Flow.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Destiny.Core.Flow.Validation.Interceptor
{
    public class MethodInvocationValidator
    {
        private const int MaxRecursiveParameterValidationDepth = 8;

        private readonly IEnumerable<IMethodParameterValidator> _validators;
        private readonly IList<ValidationFailure> _failures;

        public MethodInvocationValidator(

            IEnumerable<IMethodParameterValidator> validators)
        {

            _validators = validators ?? throw new ArgumentNullException(nameof(validators));

            _failures = new List<ValidationFailure>();
        }

        public IEnumerable<ValidationFailure> Validate(MethodInfo method, object[] parameterValues)
        {
            method.NotNull(nameof(method));
            method.NotNull(nameof(parameterValues));



            var parameters = method.GetParameters();

            if (parameters.Length != parameterValues.Length)
            {
                throw new Exception("方法参数计数与参数计数不匹配!");
            }

            for (var i = 0; i < parameters.Length; i++)
            {
                ValidateMethodParameter(parameters[i], parameterValues[i]);
            }

            return _failures;
        }

        private void ValidateMethodParameter(ParameterInfo parameterInfo, object parameterValue)
        {
            if (parameterValue == null)
            {
                if (!parameterInfo.IsOptional &&
                    !parameterInfo.IsOut &&
                    !parameterInfo.ParameterType.IsPrimitiveExtendedIncludingNullable(true))
                {
                    _failures.Add(new ValidationFailure(parameterInfo.Name, parameterInfo.Name + " 为空!"));
                }

                return;
            }

            ValidateObjectRecursively(parameterValue, 1);
        }

        private void ValidateObjectRecursively(object validatingObject, int depth)
        {
            if (depth > MaxRecursiveParameterValidationDepth)
            {
                return;
            }

            if (validatingObject == null)
            {
                return;
            }



            if (validatingObject.GetType().IsPrimitiveExtendedIncludingNullable())
            {
                return;
            }

            SetValidationErrors(validatingObject);

            // 验证可枚举项
            if (IsEnumerable(validatingObject))
            {
                foreach (var item in (IEnumerable)validatingObject)
                {
                    ValidateObjectRecursively(item, depth + 1);
                }
            }

            if (!ShouldMakeDeepValidation(validatingObject)) return;

            var properties = TypeDescriptor.GetProperties(validatingObject).Cast<PropertyDescriptor>();
            foreach (var property in properties)
            {


                ValidateObjectRecursively(property.GetValue(validatingObject), depth + 1);
            }
        }

        private void SetValidationErrors(object parameter)
        {
            foreach (var validator in _validators)
            {
                var failures = validator.Validate(parameter);
                _failures.AddRange(failures);
            }
        }
        private static bool ShouldMakeDeepValidation(object validatingObject)
        {
            // 不递归验证可枚举对象
            if (validatingObject is IEnumerable)
            {
                return false;
            }

            var validatingObjectType = validatingObject.GetType();

            // 不递归验证基元对象
            return !validatingObjectType.IsPrimitiveExtendedIncludingNullable();
        }


        private static bool IsEnumerable(object validatingObject)
        {
            return
                validatingObject is IEnumerable &&
                !(validatingObject is IQueryable) &&
                !validatingObject.GetType().IsPrimitiveExtendedIncludingNullable();
        }

    }
}
