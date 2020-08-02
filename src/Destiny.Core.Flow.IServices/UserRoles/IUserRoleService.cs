using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.UserRoles
{
   public interface IUserRoleService: IScopedDependency
    {


        IQueryable<UserRole> UserRoles { get; }

        IQueryable<UserRole> TrackUserRoles { get; }

        Task<Guid[]> GetRoleIdsByUserIdAsync(Guid userId);
    }
}
