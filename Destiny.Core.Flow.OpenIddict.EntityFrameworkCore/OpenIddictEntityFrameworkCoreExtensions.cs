using Destiny.Core.Flow.Model.Entities.OpenIddict;
using Destiny.Core.Flow.OpenIddict.EntityFrameworkCore.Store;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenIddict.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.OpenIddict.EntityFrameworkCore
{
    public static class OpenIddictEntityFrameworkCoreExtensions
    {
        /// <summary>
        /// 注册efcore store服务
        /// 配置 OpenIddict 实体
        /// </summary>
        /// <returns>The <see cref="OpenIddictEntityFrameworkCoreBuilder"/>.</returns>
        public static OpenIddictEntityFrameworkCoreBuilder UseEntityFrameworkCore(this OpenIddictCoreBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Since Entity Framework Core may be used with databases performing case-insensitive
            // or culture-sensitive comparisons, ensure the additional filtering logic is enforced
            // in case case-sensitive stores were registered before this extension was called.
            builder.Configure(options => options.DisableAdditionalFiltering = false);

            //builder.SetDefaultApplicationEntity<Application>()
            //       .SetDefaultAuthorizationEntity<Authorization>()
            //       .SetDefaultScopeEntity<Scope>()
            //       .SetDefaultTokenEntity<Token>();

            builder.ReplaceApplicationStoreResolver<OpenIddictEntityFrameworkCoreApplicationStoreResolver>()
                   .ReplaceAuthorizationStoreResolver<OpenIddictEntityFrameworkCoreAuthorizationStoreResolver>()
                   .ReplaceScopeStoreResolver<OpenIddictEntityFrameworkCoreScopeStoreResolver>()
                   .ReplaceTokenStoreResolver<OpenIddictEntityFrameworkCoreTokenStoreResolver>();

            builder.Services.TryAddSingleton<OpenIddictEntityFrameworkCoreApplicationStoreResolver.TypeResolutionCache>();
            builder.Services.TryAddSingleton<OpenIddictEntityFrameworkCoreAuthorizationStoreResolver.TypeResolutionCache>();
            builder.Services.TryAddSingleton<OpenIddictEntityFrameworkCoreScopeStoreResolver.TypeResolutionCache>();
            builder.Services.TryAddSingleton<OpenIddictEntityFrameworkCoreTokenStoreResolver.TypeResolutionCache>();

            builder.Services.TryAddScoped(typeof(Store.OpenIddictEntityFrameworkCoreApplicationStore<,,,,>));
            builder.Services.TryAddScoped(typeof(Store.OpenIddictEntityFrameworkCoreAuthorizationStore<,,,,>));
            builder.Services.TryAddScoped(typeof(Store.OpenIddictEntityFrameworkCoreScopeStore<,,>));
            builder.Services.TryAddScoped(typeof(Store.OpenIddictEntityFrameworkCoreTokenStore<,,,,>));

            return new OpenIddictEntityFrameworkCoreBuilder(builder.Services);
        }

        /// <summary>
        /// 注册efcore store服务
        /// 配置 OpenIddict 实体
        /// </summary>
        /// <remarks>此扩展方法可多次调用</remarks>
        /// <returns>The <see cref="OpenIddictCoreBuilder"/>.</returns>
        public static OpenIddictCoreBuilder UseEntityFrameworkCore(
            this OpenIddictCoreBuilder builder, Action<OpenIddictEntityFrameworkCoreBuilder> configuration)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration(builder.UseEntityFrameworkCore());

            return builder;
        }
    }
}
