using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Destiny.Core.Flow.Validation;
using FluentValidation;

namespace Destiny.Core.Flow.FluentValidation
{
    public class FluentValidationModuleBase : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var assemblyFinder = context.Services.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>();
            assemblyFinder.NotNull(nameof(assemblyFinder));
            context.Services.AddValidatorsFromAssemblies(assemblyFinder.FindAll());
            context.Services.WithFluentValidation();
            context.Services.WithModelValidation();
        }



    }
}
