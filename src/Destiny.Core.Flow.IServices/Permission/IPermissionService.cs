using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Permissions;
using Destiny.Core.Flow.Ui;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Permission
{
    /// <summary>
    /// 权限接口
    /// </summary>
    public interface IPermissionService : IScopedDependency
    {
        Task<OperationResponse<RolePermissionOutputDto[]>> GetRolePermissionListAsync();
    }
}