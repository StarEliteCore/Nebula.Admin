using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Organization;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Organization
{
    public interface IOrganizationService : IScopedDependency
    {
        /// <summary>
        /// 新增组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(OrganizationInputDto input);

        /// <summary>
        /// 新增组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(OrganizationInputDto input);

        /// <summary>
        /// 删除一个组织架构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        Task<TreeResult<OrganizationOutDto>> GetOrganization();
        /// <summary>
        /// 得到组织架构分页数据（不是树，只是普通表格）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<OrganizationOutPageListDto>> GetPageOrganizationAsync(PageRequest request);
        /// <summary>
        /// 根据Id 获取一个组织架构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse<OrganizationOutputLoadDto>> LoadFormOrganizationAsync(Guid id);
    }
}
