
using Destiny.Core.Flow.Shared.Abstractions;
using DestinyCore;
using DestinyCore.Entity;
using DestinyCore.Extensions;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using DestinyCore.Ui;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Shared.Application
{
    public class CrudServiceAsync<TPrimaryKey, IEntity, IInputDto, IOutputDto, IPagedListDto> : ICrudServiceAsync<TPrimaryKey, IEntity, IInputDto, IOutputDto, IPagedListDto>
              where IEntity : EntityBase<TPrimaryKey>
              where TPrimaryKey : IEquatable<TPrimaryKey>
              where IInputDto : IInputDto<TPrimaryKey>
              where IPagedListDto:IOutputDto<TPrimaryKey>
              where IOutputDto : IOutputDto<TPrimaryKey>
    {
        protected IServiceProvider ServiceProvider { get; set; }
        protected IRepository<IEntity, TPrimaryKey> Repository { get; set; }
        protected ILogger Logger { get; set; }


        public CrudServiceAsync(IServiceProvider serviceProvider, IRepository<IEntity, TPrimaryKey> repository, ILoggerFactory loggerFactory)
        {
            this.ServiceProvider = serviceProvider;
            this.Repository = repository;
            this.Logger = loggerFactory.CreateLogger<CrudServiceAsync<TPrimaryKey, IEntity, IInputDto, IOutputDto, IPagedListDto>>();
        }

        protected IQueryable<IEntity> Entities => this.Repository.Entities;

        protected IQueryable<IEntity> TrackEntities => this.Repository.TrackEntities;

        public virtual async Task<OperationResponse> CreateAsync(IInputDto inputDto)
        {
            inputDto.NotNull(nameof(inputDto));

            return await this.Repository.InsertAsync(inputDto,this.CreateCheckAsync);
        }


        /// <summary>
        /// 创建检查
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        protected virtual Task CreateCheckAsync(IInputDto dto)
        {
            return Task.CompletedTask;
        }


        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        public virtual Task<OperationResponse> DeleteAsync(TPrimaryKey key)
        {
            return this.Repository.DeleteAsync(key);
        }

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public virtual Task<OperationResponse> UpdateAsync(IInputDto inputDto)
        {
            inputDto.NotNull(nameof(inputDto));
            return this.Repository.UpdateAsync<IInputDto>(inputDto,this.UpdateCheckAsync);
        }


        /// <summary>
        ///更新检查
        /// </summary>
        /// <param name="inputDto"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual Task UpdateCheckAsync(IInputDto inputDto, IEntity entity)
        {
            return Task.CompletedTask;

        }

        /// <summary>
        /// 异步得到分页数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual Task<IPagedResult<IPagedListDto>> GetPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            return this.Entities.ToPageAsync<IEntity,IPagedListDto>(request);
        }

        /// <summary>
        /// 异步根据键加载数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<OperationResponse<IOutputDto>> LoadDataByKeyAsync(TPrimaryKey key)
        {
        
            var entity =await this.FindEntityByKeyAsync(key);
            var dto= entity.MapTo<IOutputDto>();
            return OperationResponse<IOutputDto>.Ok(dto);
        }

        /// <summary>
        /// 异步根据键查找实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual Task<IEntity> FindEntityByKeyAsync(TPrimaryKey key)
        {
            key.NotNull(nameof(key));
            return this.Repository.GetByIdAsync(key);
        }

        /// <summary>
        /// 创建或更新异步
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public virtual async Task<OperationResponse> CreateOrUpdateAsync(IInputDto inputDto)
        {

            var entity =await FindEntityByKeyAsync(inputDto.Id);
            if (entity is null)
            {
              return  await this.CreateAsync(inputDto);
            }
            return await this.UpdateAsync(inputDto);
            
        }
    }
}
