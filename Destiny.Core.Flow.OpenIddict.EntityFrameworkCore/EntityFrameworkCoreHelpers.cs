using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Destiny.Core.Flow.OpenIddict.EntityFrameworkCore
{
    public static class EntityFrameworkCoreHelpers
    {
        public static IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IQueryable<T> source, CancellationToken cancellationToken)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return ExecuteAsync(source, cancellationToken);

            static async IAsyncEnumerable<T> ExecuteAsync(IQueryable<T> source, [EnumeratorCancellation] CancellationToken cancellationToken)
            {
#if SUPPORTS_BCL_ASYNC_ENUMERABLE
                await foreach (var element in source.AsAsyncEnumerable().WithCancellation(cancellationToken))
                {
                    yield return element;
                }
#else
                foreach (var element in await source.ToListAsync(cancellationToken))
                {
                    yield return element;
                }
#endif
            }
        }
    }
}
