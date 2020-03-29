using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Entity
{
    public class OutputDto<TKey> : IOutputDto<TKey>
    {
        public TKey Id { get; set; }
    }

    public class OutputDto : IOutputDto
    { 
    
    }
}
