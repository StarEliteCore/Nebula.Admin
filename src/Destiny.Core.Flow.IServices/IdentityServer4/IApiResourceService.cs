using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.IdentityServer4;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<OperationResponse> CreateApiResourceAsync(ApiResourceInputDto dto);


        /// <summary>
        /// 异步更新Api资源
        /// </summary>
        /// <param name="dto">要传入DTO</param>
        /// <returns></returns>

        Task<OperationResponse> UpdateApiResourceAsync(ApiResourceInputDto dto);

        /// <summary>
        /// 异步创建或更新Api资源
        /// </summary>
        /// <param name="dto">要传入DTO</param>
        /// <returns></returns>
        Task<OperationResponse> CreateOrUpdateApiResourceAsync(ApiResourceInputDto dto);

        /// <summary>
        /// 得到JWTClaim类型下拉项
        /// </summary>
        /// <returns></returns>
        OperationResponse GetJwtClaimTypeSelectItem();

        /// <summary>
        /// 异步加载Api资源数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OperationResponse> LoadApiResourceDataAsync(Guid Id);


        /// <summary>
        /// 异步得到Api资源分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<ApiResourceOutputPageListDto>> GetApiResourcePageAsync(PageRequest request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);
        /// <summary>
        /// 获取API资源下拉框列表
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse<IEnumerable<SelectListItem>>> GetApiResourceSelectItemAsync();





    }
}
