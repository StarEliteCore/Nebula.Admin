using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.IServices;
using Destiny.Core.Flow.IServices.UserRoles;
using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services
{
    [Dependency(ServiceLifetime.Scoped)]
    public class Test1 : ITest1
    {

        private readonly UserManager<User> _userManager = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IUserRoleService _userRoleService = null;

        public Test1(UserManager<User> userManager, RoleManager<Role> roleManager, IUnitOfWork unitOfWork, IUserRoleService userRoleService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _userRoleService = userRoleService;
        }

        public async Task Tstes()
        {
            Console.WriteLine("测试AOP");
            await Task.CompletedTask;
        }
    }
}
