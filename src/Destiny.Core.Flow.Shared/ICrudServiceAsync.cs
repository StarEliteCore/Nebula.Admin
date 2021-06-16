using DestinyCore.Dependency;
using DestinyCore.Entity;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using DestinyCore.Ui;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Shared.Abstractions
{
    public interface ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IOutputDto, IPagedListDto>
             where TEntity : EntityBase<TPrimaryKey>
             where TPrimaryKey : IEquatable<TPrimaryKey>
             where IInputDto : IInputDto<TPrimaryKey>
             where IPagedListDto:IOutputDto<TPrimaryKey>
             where IOutputDto : IOutputDto<TPrimaryKey>
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
        /// 创建或更新异步
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateOrUpdateAsync(IInputDto inputDto);

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



        /// <summary>
        /// 异步根据键加载数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<OperationResponse<IOutputDto>> LoadDataByKeyAsync(TPrimaryKey key);

        /// <summary>
        /// 异步根据键查找实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> FindEntityByKeyAsync(TPrimaryKey key);



    }
}