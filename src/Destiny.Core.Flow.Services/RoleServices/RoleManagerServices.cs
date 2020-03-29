using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.IServices.IRoleServices;
using Destiny.Core.Flow.Model.Entities.Identity;
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
        private readonly RoleManager<Role> _roleManager;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="roleManager"></param>
        public RoleManagerServices(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> AddRoleAsync()
        {
            var role = new Role();
            var result=await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }
        public async Task<bool> UpdateRoleAsync()
        {
            var role = new Role();
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
