using System;
using DestinyCore.AspNetCore.Api;
using DestinyCore.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Threading.Tasks;
using DestinyCore.Filter;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.IServices.DocumentTypes;
using Destiny.Core.Flow.Dtos.DocumentTypes;


namespace Destiny.Core.Flow.API.Controllers
{

    ///<summary>
    ///文档类型
    ///</summary>
    [Description("文档类型")]
    [AllowAnonymous]
    public class DocumentTypeController : AdminControllerBase
    {

        private readonly IDocumentTypeService _documentTypeService;
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService=documentTypeService;
        }
        /// <summary>
        /// 异步创建或更新文档类型
        /// </summary>
        /// <param name="dto">创建或更新的文档类型DTO</param>
        [HttpPost]
        [Description("异步创建或更新文档类型")]
        public async Task<AjaxResult> CreateOrUpdateAsync([FromBody] DocumentTypeInputDto dto)
        {
         
            return (await _documentTypeService.CreateOrUpdateAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 异步加载表单文档类型
        /// </summary>
        /// <param name="id">要加载的文档类型主键</param>
        [HttpGet]
        [Description("异步加载表单文档类型")]
        public async Task<AjaxResult>  LoadFormAsync(Guid id)
        {
            return (await _documentTypeService.LoadFormAsync(id)).ToAjaxResult();
        }
        /// <summary>
        /// 异步删除文档类型
        /// </summary>
        /// <param name="id">要删除的文档类型主键</param>
        [HttpDelete]
        [Description("异步删除文档类型")]
        public async Task<AjaxResult> DeleteAsync(Guid id)
        {
            return (await _documentTypeService.DeleteAsync(id)).ToAjaxResult();
        }
        /// <summary>
        /// 异步得到文档类型分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        [HttpPost]
        [Description("异步得到文档类型分页数据")]
        public async Task<PageList<DocumentTypePageListDto>> GetPageAsync(PageRequest request)
        {
            return (await _documentTypeService.GetPageAsync(request)).ToPageList();
        }
        /// <summary>
        /// 异步得到文档类型树数据
        /// </summary>
        /// <param name="request">请求数据</param>
        [HttpPost]
        [Description("异步得到文档类型分页数据")]
        public async Task<TreeModel<DocumentTreeOutDto>> GetDocumentTreeTreeDataAsync()
        {
            return (await _documentTypeService.GetTreeDataAsync()).ToTreeModel();

        }
    }
}
