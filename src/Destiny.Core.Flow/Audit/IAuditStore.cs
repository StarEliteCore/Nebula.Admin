using Destiny.Core.Flow.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit
{
  public interface IAuditStore: IScopedDependency
    {

          Task<bool> Save(AuditEntry auditEntry);
     
    }
}
