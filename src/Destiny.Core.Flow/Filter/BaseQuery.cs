using Destiny.Core.Flow.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    public class BaseQuery
    {
        public int PageIndex { get; set; } = 1;
        public int PageRow { get; set; } = 10;
        public string SortName { get; set; } = "Id";
        public SortDirection direction { get; set; } = SortDirection.Ascending;
    }
}
