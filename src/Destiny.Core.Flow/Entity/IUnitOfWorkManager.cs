using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Entity
{
   public interface IUnitOfWorkManager
    {

        IUnitOfWork Current { get; }

    }
}
