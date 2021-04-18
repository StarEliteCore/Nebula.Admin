



using System;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Dependency;
using System.Threading.Tasks;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;



namespace Destiny.Core.Flow.IServices.DocumentTypes
{
    ///<summary>
    ///文档类型
    ///</summary>
    public interface IDocumentTypeService : IScopedDependency
    {
        /// <summary>
        /// 异步创建文档类型
        /// </summary>
        /// <param name="dto">添加的文档类型DTO</param>
        Task<OperationResponse> CreateAsync(DocumentTypeInputDto dto);


        /// <summary>
        /// 异步更新文档类型
        /// </summary>
        /// <param name="dto">更新的文档类型DTO</param>
        Task<OperationResponse> UpdateAsync(DocumentTypeInputDto dto);

        /// <summary>
        /// 异步加载表单文档类型
        /// </summary>
        /// <param name="id">要加载的文档类型主键</param>
        Task<OperationResponse<DocumentTypeOutputDto>> LoadFormAsync(Guid id);

        /// <summary>
        /// 异步删除文档类型
        /// </summary>
        /// <param name="id">要删除的文档类型主键</param>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 异步得到文档类型分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        Task<IPagedResult<DocumentTypePageListDto>> GetPageAsync(PageRequest request);

        /// <summary>
        /// 异步创建或者更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateOrUpdateAsync(DocumentTypeInputDto dto);

    }

}
