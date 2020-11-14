using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.IServices.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 权限管理
    /// </summary>
    [Description("权限管理")]

    public class PermissionController : AdminControllerBase
    {

        private IPermissionService _permissionService = null;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
        }


        /// <summary>
        /// 异步得到权限集合
        /// </summary>
        [Description("异步得到权限集合")]
        [HttpGet]
        public async Task<AjaxResult> GetPermissionListAsync()
        {
            return (await _permissionService.GetRolePermissionListAsync()).ToAjaxResult();
        }
    }
}
