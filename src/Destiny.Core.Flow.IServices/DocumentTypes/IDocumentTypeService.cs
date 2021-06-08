



using System;
using Destiny.Core.Flow.Dtos;
using DestinyCore.Dependency;
using System.Threading.Tasks;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using DestinyCore.Ui;
using DestinyCore.Ui.Abstracts;
using Destiny.Core.Flow.Dtos.DocumentTypes;

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
        Task<OperationResponse> CreateAsync(AssetInputDto dto);


        /// <summary>
        /// 异步更新文档类型
        /// </summary>
        /// <param name="dto">更新的文档类型DTO</param>
        Task<OperationResponse> UpdateAsync(AssetInputDto dto);

        /// <summary>
        /// 异步加载表单文档类型
        /// </summary>
        /// <param name="id">要加载的文档类型主键</param>
        Task<OperationResponse<AssetOutputDto>> LoadFormAsync(Guid id);

        /// <summary>
        /// 异步删除文档类型
        /// </summary>
        /// <param name="id">要删除的文档类型主键</param>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 异步得到文档类型分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        Task<IPagedResult<AssetPageListDto>> GetPageAsync(PageRequest request);

        /// <summary>
        /// 异步创建或者更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateOrUpdateAsync(AssetInputDto dto);

        /// <summary>
        /// 异步得到树数据
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        Task<ITreeResult<DocumentTreeOutDto>> GetTreeDataAsync();

    }

}
