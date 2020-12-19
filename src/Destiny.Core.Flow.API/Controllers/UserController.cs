using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Mvc.Filters;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices;
using Destiny.Core.Flow.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
namespace Destiny.Core.Flow.API.Controllers
{

    /// <summary>
    /// 用户管理
    /// </summary>
    [Description("用户管理")]

    public class UserController : AdminControllerBase
    {

        private readonly IUserServices _userService = null;
        private readonly ILogger _logger = null;
        private readonly IServiceProvider _serviceProvider = null;
        public UserController(IUserServices userService, IServiceProvider serviceProvider)
        {
            _userService = userService;
            _logger = IocManage.GetLogger<UserController>();
            _serviceProvider = serviceProvider;
        }


        /// <summary>
        /// 异步创建用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建用户")]
        [ServiceFilter(typeof(AuditLogFilterAttribute))]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<AjaxResult> CreateAsync([FromBody] UserInputDto dto)
        {

            //var validator = _serviceProvider.GetService<IModelValidator<UserInputDto>>();

            //var failures = validator.Validate(new UserInputDto());
            return (await _userService.CreateAsync(dto)).ToAjaxResult();
        }



        /// <summary>
        /// 异步更新用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost]
        [Description("异步更新用户")]
        [ServiceFilter(typeof(AuditLogFilterAttribute))]

        public async Task<AjaxResult> UpdateAsync([FromBody] UserUpdateInputDto dto)
        {

            return (await _userService.UpdateAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步删除用户
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        [HttpDelete]
        [Description("异步删除用户")]
        public async Task<AjaxResult> DeleteAsync(Guid id)
        {

            return (await _userService.DeleteAsync(id)).ToAjaxResult();

        }



        /// <summary>
        /// 异步加载用户
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        [HttpGet]
        [Description("异步加载用户")]
        [NoAuthorityVerification]

        public async Task<AjaxResult> LoadAsync(Guid id)
        {

            return (await _userService.LoadFormUserAsync(id)).ToAjaxResult();

        }

        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <returns></returns>
        [Description("用户分配角色")]
        [HttpPost]
        public async Task<AjaxResult> AllocationRoleAsync([FromBody] UserAllocationRoleInputDto dto)
        {
            return (await _userService.AllocationRoleAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        ///获取所有用户列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [Description("获取所有用户列表")]

        public async Task<AjaxResult> GetUsersToSelectListItemAsync()
        {
            return (await _userService.GetUsersToSelectListItemAsync()).ToAjaxResult();
        }

        /// <summary>
        /// 异步得到分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到分页")]
        public async Task<PageList<UserOutputPageListDto>> GetUserPageAsync([FromBody] PageRequest request)
        {
            return (await _userService.GetUserPageAsync(request)).ToPageList();

        }
        /// <summary>
        /// 异步得到所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("异步得到所有用户")]
        [NoAuthorityVerification]
        [DisableAuditing]
        public async Task<AjaxResult> GetUsersAsync()
        {

            return (await _userService.GetUsersAsync()).ToAjaxResult();
        }
    }
}
