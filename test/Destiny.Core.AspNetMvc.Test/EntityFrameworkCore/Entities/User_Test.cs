using DestinyCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.Entities
{
    public class User_Test : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {

        public string Description { get; set; }
        public string Name { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? LastModifionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
