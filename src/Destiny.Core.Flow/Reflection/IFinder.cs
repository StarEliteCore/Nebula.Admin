using Destiny.Core.Flow.Dependency;
using System;

namespace Destiny.Core.Flow.Reflection
{
    [IgnoreDependency]
    public interface IFinder<out TItem>
    {
        TItem[] Find(Func<TItem, bool> predicate);


        TItem[] FindAll();
    }
}
