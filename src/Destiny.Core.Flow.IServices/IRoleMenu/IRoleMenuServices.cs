using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IRoleMenu
{
    public interface IRoleMenuServices: IScopedDependency
    {
        /// <summary>
        /// 添加一个菜单权限
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> CareateAsync();

        
        /// <summary>
        /// 删除一个菜单权限
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync();
    }
}
