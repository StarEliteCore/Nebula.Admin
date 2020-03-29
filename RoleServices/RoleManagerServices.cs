using Destiny.Core.Flow.IServices.IRoleServices;
using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.RoleServices
{
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
    }
}
