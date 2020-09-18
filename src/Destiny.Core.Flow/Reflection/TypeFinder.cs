using System;
using System.Linq;

namespace Destiny.Core.Flow.Reflection
{

    public class TypeFinder : FinderBase<Type>, ITypeFinder
    {

        private readonly IAssemblyFinder _assemblyFinder = null;
        private readonly object _syncObj = new object();
        public TypeFinder(IAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder;
        }

        protected override Type[] FindAllItems()
        {
            return _assemblyFinder.FindAll().SelectMany(o => o.GetTypes()).ToArray();
        }
    }
}
