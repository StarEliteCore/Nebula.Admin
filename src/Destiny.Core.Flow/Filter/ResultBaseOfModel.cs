using Destiny.Core.Flow.Ui;

namespace Destiny.Core.Flow.Filter
{
    public abstract class ResultBase<TData> : ResultBase, IResultData<TData>
    {
        public virtual TData Data { get; set; }
    }
}
