using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
   public class PageRequest
    {
        public PageRequest()
        {

            PageParameters = new PageParameters();
            Filters = new FilterInfo[] { };
        }

        public virtual FilterInfo[] Filters { get; set; }

        public virtual PageParameters PageParameters { get; set; }
    }
}
