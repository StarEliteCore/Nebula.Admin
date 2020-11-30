using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Ui;

namespace Destiny.Core.Flow.Filter.Abstract
{
    public interface IPagedResult<TModel> : IResultBase, IListResult<TModel>, IHasResultType<AjaxResultType>
    {


        int Total { get; }
    }
}
