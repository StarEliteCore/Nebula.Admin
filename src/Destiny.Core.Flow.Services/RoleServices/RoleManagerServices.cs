using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.RoleDtos;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.IRoleServices;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.RoleServices
{
    [Dependency(ServiceLifetime.Scoped)]
    public class RoleManagerServices: IRoleManagerServices
    {
        private readonly RoleManager<Role> _roleManager=null;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="roleManager"></param>
        public RoleManagerServices(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<OperationResponse> AddRoleAsync(RoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var role = dto.MapTo<Role>();
            var result=await _roleManager.CreateAsync(role);
            if(!result.Succeeded)
            {
                return result.ToOperationResponse();
            }
            return new OperationResponse("添加角色成功", Enums.OperationResponseType.Success);
        }
        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotNull(nameof(id));
            var role =await _roleManager.FindByIdAsync(id.ToString());
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return result.ToOperationResponse();
            }
            return new OperationResponse("删除成功!!", OperationResponseType.Success);

        }
        public async Task<OperationResponse> UpdateRoleAsync(RoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var role = await _roleManager.FindByIdAsync(dto.ToString());
            role = dto.MapTo(role);
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                return result.ToOperationResponse();
            }
            return new OperationResponse("更新成功!", Enums.OperationResponseType.Success);
        }
    }
}
