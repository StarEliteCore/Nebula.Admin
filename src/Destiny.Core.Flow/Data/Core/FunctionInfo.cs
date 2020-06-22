using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Data.Core
{
   public class FunctionInfo
    {
       public string Name { get; set; }

    
        public string Controller { get; set; }


        public string Action { get; set; }


        public bool IsEnabled { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}
