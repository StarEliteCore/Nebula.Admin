using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
  public  interface IResultData<TData>
    {
        TData Data { get; set; }
    }
}
