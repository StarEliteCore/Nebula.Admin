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
              where IEntity : IEntity<TPrimaryKey>, IEquatable<TPrimaryKey>
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

        public async Task<OperationResponse> CreateAsync(IInputDto inputDto)
        {
            inputDto.NotNull(nameof(inputDto));

            return await this.Repository.InsertAsync(inputDto, CheckInsertFunc);
        }

        protected  Func<IInputDto, Task> CheckInsertFunc = null;

      
        public Task<OperationResponse> DeleteAsync(TPrimaryKey key)
        {
            return this.Repository.DeleteAsync(key);
        }

        public Task<OperationResponse> UpdateAsync(IInputDto inputDto)
        {
            inputDto.NotNull(nameof(inputDto));
            return this.Repository.UpdateAsync<IInputDto>(inputDto);
        }


        /// <summary>
        /// 异步得到分页数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<IPagedResult<IPagedListDto>> GetPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            return this.Entities.ToPageAsync<IEntity,IPagedListDto>(request);
        }
    }
}
