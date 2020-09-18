

using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Destiny.Core.Flow.Extensions
{
    public static partial class Extensions
    {
        public static OperationResponse ToOperationResponse(this IdentityResult identityResult)
        {


            return identityResult.Succeeded ? new OperationResponse(OperationResponseType.Success) : new OperationResponse(identityResult.Errors.Select(o => o.Description).ToJoin(), OperationResponseType.Error);
        }
        public static IdentityResult Failed(this IdentityResult identityResult, params string[] errors)
        {
            var identityErrors = identityResult.Errors;
            identityErrors = identityErrors.Union(errors.Select(m => new IdentityError() { Description = m }));
            return IdentityResult.Failed(identityErrors.ToArray());
        }
    }
}
