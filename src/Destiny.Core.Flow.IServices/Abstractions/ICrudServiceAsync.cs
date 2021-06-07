using DestinyCore.Entity;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using DestinyCore.Ui;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Abstractions
{
    public interface ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IPagedListDto>
             where TEntity : IEntity<TPrimaryKey>, IEquatable<TPrimaryKey>
             where IInputDto : IInputDto<TPrimaryKey>
             where IPagedListDto:IOutputDto<TPrimaryKey>
    {


        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(IInputDto inputDto);

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(IInputDto inputDto);


        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="key">按键删除</param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(TPrimaryKey key);


        /// <summary>
        /// 异步得到分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        Task<IPagedResult<IPagedListDto>> GetPageAsync(PageRequest request);
    }
}