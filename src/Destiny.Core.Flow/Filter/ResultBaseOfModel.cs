using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    public abstract class ResultBase<TData> : ResultBase, IResultData<TData>
    {
        public virtual TData Data { get;  set; }
    }
}
