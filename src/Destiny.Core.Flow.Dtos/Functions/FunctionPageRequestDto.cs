using Destiny.Core.Flow.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.Functions
{
    public  class FunctionPageRequestDto: PageRequest
    {

       public Guid?[] MenuIds { get; set; }
    }
}
