



using System;
using Destiny.Core.Flow.Dtos;
using DestinyCore.Dependency;
using System.Threading.Tasks;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using DestinyCore.Ui;
using DestinyCore.Ui.Abstracts;
using Destiny.Core.Flow.Dtos.DocumentTypes;

namespace Destiny.Core.Flow.IServices.Documents
{
    ///<summary>
    ///文档
    ///</summary>
    public interface IDocumentService : IScopedDependency
    {
        /// <summary>
        /// 异步创建文档
        /// </summary>
        /// <param name="dto">添加的文档DTO</param>
        Task<OperationResponse> CreateAsync(DocumentInputDto dto);


        /// <summary>
        /// 异步更新文档
        /// </summary>
        /// <param name="dto">更新的文档DTO</param>
        Task<OperationResponse> UpdateAsync(DocumentInputDto dto);

        /// <summary>
        /// 异步加载表单文档
        /// </summary>
        /// <param name="id">要加载的文档主键</param>
        Task<OperationResponse<DocumentOutputDto>> LoadFormAsync(Guid id);

        /// <summary>
        /// 异步删除文档
        /// </summary>
        /// <param name="id">要删除的文档主键</param>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 异步得到文档分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        Task<IPagedResult<DocumentPageListDto>> GetPageAsync(PageRequest request);


        

    }

}
