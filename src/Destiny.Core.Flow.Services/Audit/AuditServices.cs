using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Audit
{
    public class AuditServices : IAuditStore
    {
    
        public async Task<bool> Save(AuditEntry auditEntry )
        {


            await Task.CompletedTask;
            return true;
        }
    }
}
