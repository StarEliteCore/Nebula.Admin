using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Validation.Interceptor
{
    public interface IMethodParameterValidator 
    {
        IEnumerable<ValidationFailure> Validate(object parameter);
    }
}
