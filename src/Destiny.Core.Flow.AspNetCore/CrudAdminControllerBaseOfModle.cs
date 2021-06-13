
using Destiny.Core.Flow.Shared.Abstractions;
using DestinyCore.AspNetCore;
using DestinyCore.AspNetCore.Api;
using DestinyCore.Entity;
using DestinyCore.Filter;
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


    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class CrudApiControllerBase<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto>: ApiControllerBase
          where TEntity : EntityBase<TPrimaryKey>
              where TPrimaryKey : IEquatable<TPrimaryKey>
             where IInputDto : IInputDto<TPrimaryKey>
             where IPagedListDto : IOutputDto<TPrimaryKey>
            where IIOutputDto : IOutputDto<TPrimaryKey>
    {
        protected ICrudServiceAsync<TPrimaryKey, TEntity, IInputDto, IIOutputDto, IPagedListDto> CrudServiceAsync { get; set; }
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
        public virtual async Task<AjaxResult> DeleteAsync(TPrimaryKey id)
        {

            return (await CrudServiceAsync.DeleteAsync(id)).ToAjaxResult();

        }

        [Description("异步得到分页")]
        [HttpPost]
        public async Task<PageList<IPagedListDto>> GetPageAsync([FromBody] PageRequest request)
        {
            return (await CrudServiceAsync.GetPageAsync(request)).ToPageList();

        }
    }

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
}
