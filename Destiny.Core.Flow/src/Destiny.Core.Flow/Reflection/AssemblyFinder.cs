using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Reflection
{
    public class AssemblyFinder : FinderBase<Assembly>, IAssemblyFinder
    {
        protected override Assembly[] FindAllItems()
        {
          return  AssemblyHelper.FindAllItems();
        }
    }
}
