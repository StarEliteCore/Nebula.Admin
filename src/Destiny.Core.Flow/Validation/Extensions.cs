using Destiny.Core.Flow.Validation.Interceptor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Validation
{
   public  static partial  class Extensions
    {

        public static IServiceCollection WithModelValidation(this IServiceCollection services)
        {
            services.AddTransient<MethodInvocationValidator>();
            services.AddTransient<IMethodParameterValidator, ModelValidationMethodParameterValidator>();
            return services;
        }
    }
}
