
using Destiny.Core.Flow.Shared.Abstractions;
using DestinyCore.AspNetCore;
using DestinyCore.AspNetCore.Api;
using DestinyCore.Entity;
using DestinyCore.Enums;
using DestinyCore.Extensions;
using DestinyCore.Filter;
using DestinyCore.Ui;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore
{

    /// <summary>
    /// 增删改查权API制器(无权限)
    /// </summary>
    /// <typeparam name="ICrudService">增删改查服务</typeparam>
    /// <typeparam name="TPrimaryKey">键</typeparam>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="IInputDto">输入DTO</typeparam>
    /// <typeparam name="IIOutputDto">输出DTO</typeparam>
    /// <typeparam name="IPagedListDto">分页DTO</typeparam>
    public abstract class CrudApiControllerBase<ICrudService, TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto> : CrudApiControllerBase<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto>
            where TEntity : EntityBase<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>
            where IInputDto : IInputDto<TPrimaryKey>
            where IPagedListDto : IOutputDto<TPrimaryKey>
            where IIOutputDto : IOutputDto<TPrimaryKey>
            where ICrudService : ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto>
    {

        
        protected CrudApiControllerBase(ICrudService crudServiceAsync):base(crudServiceAsync)
        {

            this.CrudServiceAsync = crudServiceAsync;
        }

    }

    /// <summary>
    /// 增删改查权API制器(无权限)
    /// </summary>
    /// <typeparam name="TPrimaryKey">键</typeparam>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="IInputDto">输入DTO</typeparam>
    /// <typeparam name="IIOutputDto">输出DTO</typeparam>
    /// <typeparam name="IPagedListDto">分页DTO</typeparam>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class CrudApiControllerBase<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto>: ApiControllerBase
          where TEntity : EntityBase<TPrimaryKey>
          where TPrimaryKey : IEquatable<TPrimaryKey>
          where IInputDto : IInputDto<TPrimaryKey>
          where IPagedListDto : IOutputDto<TPrimaryKey>
          where IIOutputDto : IOutputDto<TPrimaryKey>
    {
        protected virtual ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto> CrudServiceAsync { get; set; }
        protected CrudApiControllerBase(ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto> crudServiceAsync)
        {

            this.CrudServiceAsync = crudServiceAsync;
        }

      
        [Description("异步创建")]
        [HttpPost]
        public virtual async Task<AjaxResult> CreateAsync([FromBody] IInputDto dto)
        {

            return (await CrudServiceAsync.CreateAsync(dto)).ToAjaxResult();
        }

        [HttpGet]
        public virtual async Task<AjaxResult> LoadDataAsync(TPrimaryKey key) {

            return (await CrudServiceAsync.LoadDataByKeyAsync(key)).ToAjaxResult();

        }

        [Description("异步更新")]
        [HttpPost]
        public virtual async Task<AjaxResult> UpdateAsync([FromBody] IInputDto dto)
        {

            return (await CrudServiceAsync.UpdateAsync(dto)).ToAjaxResult();
        }

        [Description("异步删除")]
        [HttpDelete]
        public virtual async Task<AjaxResult> DeleteAsync(TPrimaryKey key)
        {

            return (await CrudServiceAsync.DeleteAsync(key)).ToAjaxResult();

        }

        [Description("异步得到分页")]
        [HttpPost]
        public virtual async Task<PageList<IPagedListDto>> GetPageAsync([FromBody] PageRequest request)
        {
            return (await CrudServiceAsync.GetPageAsync(request)).ToPageList();

        }

        /// <summary>
        /// 异步创建或更新
        /// </summary>
        /// <param name="dto"></param>
        [Description("异步创建或更新")]
        [HttpPost]
        public virtual async Task<AjaxResult> CreateOrUpdateAsync([FromBody] IInputDto dto)
        {
            return (await CrudServiceAsync.CreateOrUpdateAsync(dto)).ToAjaxResult();
        }


      


    }


    /// <summary>
    /// 增删改查控制器(有权限)
    /// </summary>
    /// <typeparam name="TPrimaryKey">键</typeparam>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="IInputDto">输入DTO</typeparam>
    /// <typeparam name="IIOutputDto">输出DTO</typeparam>
    /// <typeparam name="IPagedListDto">分页DTO</typeparam>
    [Authorize]
    public abstract class CrudAdminControllerBase<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto> : CrudApiControllerBase<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto>
              where TEntity :  EntityBase<TPrimaryKey>
              where TPrimaryKey : IEquatable<TPrimaryKey>
              where IInputDto : IInputDto<TPrimaryKey>
              where IPagedListDto : IOutputDto<TPrimaryKey>
              where IIOutputDto : IOutputDto<TPrimaryKey>
    {



        protected CrudAdminControllerBase(ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto> crudServiceAsync):base(crudServiceAsync)
        {

            this.CrudServiceAsync = crudServiceAsync;
        }

    }

    /// <summary>
    /// 增删改查控制器(有权限)
    /// </summary>
    /// <typeparam name="ICrudService">增删改查服务</typeparam>
    /// <typeparam name="TPrimaryKey">键</typeparam>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="IInputDto">输入DTO</typeparam>
    /// <typeparam name="IIOutputDto">输出DTO</typeparam>
    /// <typeparam name="IPagedListDto">分页DTO</typeparam>

    [Authorize]
    public abstract class CrudAdminControllerBase<ICrudService, TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto> : CrudApiControllerBase<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto>
             where TEntity : EntityBase<TPrimaryKey>
             where TPrimaryKey : IEquatable<TPrimaryKey>
             where IInputDto : IInputDto<TPrimaryKey>
             where IPagedListDto : IOutputDto<TPrimaryKey>
             where IIOutputDto : IOutputDto<TPrimaryKey>
             where ICrudService : ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto>
    {

        protected CrudAdminControllerBase(ICrudService crudServiceAsync) : base(crudServiceAsync)
        {

            this.CrudServiceAsync = crudServiceAsync;
        }

    }
}
