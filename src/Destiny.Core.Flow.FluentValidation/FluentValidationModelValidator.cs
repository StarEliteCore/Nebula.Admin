using Destiny.Core.Flow.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Destiny.Core.Flow.FluentValidation
{
    internal class FluentValidationModelValidator<T> : ModelValidator<T>
    {
        private readonly IValidatorFactory _factory;

        public FluentValidationModelValidator(IValidatorFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public override IEnumerable<ValidationFailure> Validate(T model)
        {
            var fvValidator = _factory.GetValidator(model.GetType());

            if (fvValidator == null) return Enumerable.Empty<ValidationFailure>();

            var validationResult = fvValidator.Validate((IValidationContext)model);
            var failures = validationResult.Errors
                .Select(e => new ValidationFailure(e.PropertyName, e.ErrorMessage))
                .ToList();

            return failures;
        }
    }
}
