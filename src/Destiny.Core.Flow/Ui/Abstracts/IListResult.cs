using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Ui
{
    public interface IListResult<T>:IResultBase
    {
        IReadOnlyList<T> ItemList { get; set; }
    }
}
