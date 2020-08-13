using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Entity
{
   public  interface IDto<TKey>
    {
        TKey Id { get; set; }
    }


    public abstract class DtoBase<TKey> : IDto<TKey>
    {
        public virtual TKey Id { get; set; }

       
    }
}
