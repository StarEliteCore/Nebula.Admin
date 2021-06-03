using DestinyCore.Dependency;
using DestinyCore.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IdentityServer4
{
    /// <summary>
    /// API资源范围服务
    /// </summary>
    public interface IApiResourceScopeService : IScopedDependency
    {

        /// <summary>
        /// 异步得到API资源范围集合数据
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> GetApiResourceScopeListAsync();
   
    }
}
