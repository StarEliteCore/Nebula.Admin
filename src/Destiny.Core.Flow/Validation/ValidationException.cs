using Destiny.Core.Flow.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Destiny.Core.Flow.Validation
{
    [Serializable]
    public class ValidationException : AppException
    {
        public IReadOnlyList<ValidationFailure> Failures { get; }

        public ValidationException(string message) : this(message, Enumerable.Empty<ValidationFailure>())
        {
        }

        public ValidationException(string message, IEnumerable<ValidationFailure> failures) : base(message)
        {
            Failures = failures.ToList();
        }
    }
}
