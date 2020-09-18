using AspectCore.DynamicProxy;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;
using Destiny.Core.Flow.Validation.Interceptor;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Validation
{
    public sealed class ValidationInterceptorAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var validator = (MethodInvocationValidator)context.ServiceProvider.GetService(typeof(MethodInvocationValidator));

            MethodInfo method;
            try
            {

                method = context.ImplementationMethod;
            }
            catch
            {
                method = context.ServiceMethod;
            }
            var failures = validator.Validate(method, context.Parameters);

            var result = failures.ToResult();
            if (result.Success)
            {
                await next(context);
                return;
            }

            if (context.IsAsync())
            {
                if (context.ImplementationMethod.ReturnType == typeof(Task))
                {
                    ThrowValidationException(result);
                    //throw new Exception(result.Data.Select(o=>o.Message).ToJoin());
                }
                else
                {
                    var returnType = context.ImplementationMethod.ReturnType.GenericTypeArguments[0];
                    if (typeof(IResultBase).IsAssignableFrom(returnType))
                    {
                        context.ReturnValue = Task.FromResult(new OperationResponse()
                        {

                            Message = result.Message.IsNullOrEmpty() ? result.Data.Select(o => o.Message).ToJoin() : result.Message,
                            Type = Enums.OperationResponseType.Error
                        });

                    }
                    else
                    {
                        ThrowValidationException(result);
                    }
                    //ThrowValidationException(result);
                }
            }

        }

        private static void ThrowValidationException(OperationResponse<IEnumerable<ValidationFailure>> result)
        {

            throw new ValidationException(result.Message, result.Data);
        }
    }
}
