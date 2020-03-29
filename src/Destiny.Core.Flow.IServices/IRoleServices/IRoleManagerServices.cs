using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IRoleServices
{
    public interface IRoleManagerServices
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        Task<bool> AddRoleAsync();
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <returns></returns>
        Task<bool> UpdateRoleAsync();
    }
}
