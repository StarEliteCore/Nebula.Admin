using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Destiny.Core.Flow.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.FluentValidation
{
  public abstract  class FluentValidationModuleBase : AppModuleBase
    {

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
       
            var assemblyFinder = services.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>();
            assemblyFinder.NotNull(nameof(assemblyFinder));
            services.AddValidatorsFromAssemblies(assemblyFinder.FindAll());
            services.WithFluentValidation();
            services.WithModelValidation();
            return services;
        }

  
    }
}
