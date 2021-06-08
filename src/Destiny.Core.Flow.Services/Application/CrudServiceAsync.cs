using Destiny.Core.Flow.IServices.Abstractions;
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
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Application
{
    public class CrudServiceAsync<TPrimaryKey, IEntity, IInputDto, IPagedListDto> : ICrudServiceAsync<TPrimaryKey, IEntity, IInputDto, IPagedListDto>
             where IEntity : class, IEntity<TPrimaryKey>
              where TPrimaryKey : IEquatable<TPrimaryKey>
              where IInputDto : class, IInputDto<TPrimaryKey>, new()
              where IPagedListDto : IOutputDto<TPrimaryKey>
    {
        protected IServiceProvider ServiceProvider { get; set; }
        protected IRepository<IEntity, TPrimaryKey> Repository { get; set; }
        protected ILogger Logger { get; set; }


        public CrudServiceAsync(IServiceProvider serviceProvider, IRepository<IEntity, TPrimaryKey> repository, ILoggerFactory loggerFactory)
        {
            this.ServiceProvider = serviceProvider;
            this.Repository = repository;
            this.Logger = loggerFactory.CreateLogger("CrudServiceAsync");
        }

        protected IQueryable<IEntity> Entities => this.Repository.Entities;




        protected IQueryable<IEntity> TrackEntities => this.Repository.TrackEntities;

        public virtual async Task<OperationResponse> CreateAsync(IInputDto inputDto)
        {
            inputDto.NotNull(nameof(inputDto));

            return await this.Repository.InsertAsync(inputDto,this.InsertCheckAsync);
        }


        /// <summary>
        /// 插入检查
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        protected virtual Task InsertCheckAsync(IInputDto dto)
        {
            return Task.CompletedTask;
        }




        public virtual Task<OperationResponse> DeleteAsync(TPrimaryKey key)
        {
            return this.Repository.DeleteAsync(key);
        }

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
    }
}
