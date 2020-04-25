using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter.Abstract
{
    public interface IFilteredPagedRequest: IPagedRequest
    {

        FilterInfo[] Filters { get; set; }
    }
}
