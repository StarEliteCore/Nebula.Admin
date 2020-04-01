using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Destiny.Core.Flow.API.Controllers
{

    /// <summary>
    /// 用户管理
    /// </summary>
    [Description("用户管理")]
    [Authorize]
    public class UserController : ApiControllerBase
    {

        private readonly IUserServices _userService = null;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// 异步创建用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建用户")]

        public async Task<AjaxResult> CreateAsync([FromBody]UserInputDto dto)
        {

            return (await _userService.CreateAsync(dto)).ToAjaxResult();
        }



        /// <summary>
        /// 异步更新用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost]
        [Description("异步更新用户")]

        public async Task<AjaxResult> UpdateAsync([FromBody]UserInputDto dto)
        {

            return (await _userService.UpdateAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步删除用户
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        [HttpPost]
        [Description("异步删除用户")]
        public async Task<AjaxResult> DeleteAsync(Guid? id)
        {

            return (await _userService.DeleteAsync(id.Value)).ToAjaxResult();

        }



        /// <summary>
        /// 异步加载用户
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        [HttpPost]
        [Description("异步加载用户")]


        public async Task<AjaxResult> LoadAsync(Guid id)
        {
    
            return (await _userService.LoadFormUserAsync(id)).ToAjaxResult();

        }

        /// <summary>
        ///异步添加或更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步添加或更新")]

        public async Task<AjaxResult> AddOrUpdateAsync([FromBody]UserInputDto dto)
        {
            if (dto.Id == Guid.Empty)
            {
                return (await _userService.CreateAsync(dto)).ToAjaxResult();
            }
            return (await _userService.UpdateAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步得到分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到分页")]
        public async Task<PageList<UserOutputPageListDto>> GetUserPageAsync([FromBody]PageRequest request)
        {

            return (await _userService.GetUserPageAsync(request)).PageList();
        }
    }
}