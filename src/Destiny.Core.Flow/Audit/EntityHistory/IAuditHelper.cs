using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Dependency;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Audit.EntityHistory
{
   /// <summary>
   /// 审计帮助
   /// </summary>
    public interface IAuditHelper : ITransientDependency
    {
        /// <summary>
        /// 得到实体审计
        /// </summary>
        /// <param name="entityEntries"></param>
        /// <returns></returns>
        IEnumerable<AuditEntryDto> GetAuditEntity(IEnumerable<EntityEntry> entityEntries);
    }
}
