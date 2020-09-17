using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Organization;
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
    }
}