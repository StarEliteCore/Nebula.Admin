using Destiny.Core.Flow.Validation.Interceptor;
using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.Flow.Validation
{
    public static partial class Extensions
    {

        public static IServiceCollection WithModelValidation(this IServiceCollection services)
        {
            services.AddTransient<MethodInvocationValidator>();
            services.AddTransient<IMethodParameterValidator, ModelValidationMethodParameterValidator>();
            return services;
        }
    }
}
