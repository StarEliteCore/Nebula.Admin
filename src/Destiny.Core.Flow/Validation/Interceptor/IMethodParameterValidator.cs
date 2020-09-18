using System.Collections.Generic;

namespace Destiny.Core.Flow.Validation.Interceptor
{
    public interface IMethodParameterValidator
    {
        IEnumerable<ValidationFailure> Validate(object parameter);
    }
}
