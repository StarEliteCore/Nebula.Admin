using System;

namespace Destiny.Core.Flow.Reflection
{

    public interface ITypeFinder
    {
        Type[] Find(Func<Type, bool> predicate);

        Type[] FindAll();
    }
}
