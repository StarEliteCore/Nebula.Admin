using System;
using System.Threading.Tasks;
using Destiny.Core.Flow.Dtos.IdentityServer4;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.IdentityServer4;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Destiny.Core.Flow.Ui;

namespace Destiny.Core.Flow.Services.IdentityServer4
{
    /// <summary>
    /// API资源服务
    /// </summary>
    public class ApiResourceService:IApiResourceService
    {
        
        private readonly IRepository<ApiResource, Guid> _apiResourceRepository;


        public ApiResourceService(IRepository<ApiResource, Guid> apiResourceRepository)
        {

            this._apiResourceRepository = apiResourceRepository;
        }

        /// <summary>
        /// 异步创建Api资源
        /// </summary>
        /// <param name="dto">要传入DTO</param>
        /// <returns></returns>
        public async Task<OperationResponse> CreateApiResourceAsync(ApiResourceInputDto dto)
        { 
            dto.NotNull(nameof(dto));
            return await  _apiResourceRepository.InsertAsync(dto);
        }
    }
}