using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Ui
{
    public interface IListResult<T>
    {
        IReadOnlyList<T> ItemList { get; set; }
    }
}
