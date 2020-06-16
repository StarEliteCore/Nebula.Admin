using Destiny.Core.Flow.Dtos.Permissions;
using Destiny.Core.Flow.Dtos.RoleDtos;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Permission
{
    /// <summary>
    /// 权限接口
    /// </summary>
    public interface IPermissionService
    {

        Task<OperationResponse<RolePermissionOutputDto[]>> GetRolePermissionListAsync();

    }
}
