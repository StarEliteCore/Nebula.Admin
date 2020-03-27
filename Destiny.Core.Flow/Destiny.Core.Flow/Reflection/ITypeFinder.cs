using Destiny.Core.Flow.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Reflection
{

    public interface ITypeFinder 
    {
        Type[] Find(Func<Type, bool> predicate);

        Type[] FindAll();
    }
}
