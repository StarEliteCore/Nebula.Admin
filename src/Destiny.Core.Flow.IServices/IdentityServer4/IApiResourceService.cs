using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.IdentityServer4;
using Destiny.Core.Flow.Ui;

namespace Destiny.Core.Flow.IServices.IdentityServer4
{
    /// <summary>
    /// API资源服务
    /// </summary>
    public interface IApiResourceService : IScopedDependency
    {
        
        /// <summary>
        /// 异步创建Api资源
        /// </summary>
        /// <param name="dto">要伟入DTO</param>
        /// <returns></returns>
        Task<OperationResponse>  CreateApiResourceAsync(ApiResourceInputDto dto);
    }
}
