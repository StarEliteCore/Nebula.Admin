using System.Collections.Generic;

namespace Destiny.Core.Flow.Ui
{
    public interface IListResult<T> : IResultBase
    {
        IReadOnlyList<T> ItemList { get; set; }
    }
}
