using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dependency
{
    public interface IObjects<TType>
    {
        TType Value { get; set; }
    }

    public class Objects<TType> : IObjects<TType>
    {
        public Objects([CanBeNull] TType obj)
        {
            Value = obj;
        }
        public Objects()
        {

        }
        public TType Value { get; set; }
    }
}
