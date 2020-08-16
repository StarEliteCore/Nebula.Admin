using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Data.Core.Collections
{
   public interface ITypeList<in TBaseType> : IList<Type>
    {

        void Add<T>() where T : TBaseType;

        bool Contains<T>() where T : TBaseType;

        void Remove<T>() where T : TBaseType;
    }
}
