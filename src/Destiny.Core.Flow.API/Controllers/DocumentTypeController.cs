using System;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Threading.Tasks;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.IServices.DocumentTypes;
namespace Destiny.Core.Flow.API.Controllers
{

    ///<summary>
    ///文档类型
    ///</summary>
    [Description("文档类型")]
    public class DocumentTypeController : AdminControllerBase
    {

        private readonly IDocumentTypeService _documentTypeService;
        
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService=documentTypeService;
        }


        /// <summary>
        /// 异步创建文档类型
        /// </summary>
        /// <param name="dto">添加的文档类型DTO</param>
        [HttpPost]
        [Description("异步创建文档类型")]
        public async Task<AjaxResult> CreateAsync([FromBody] DocumentTypeInputDto dto)
        {
            return (await _documentTypeService.CreateAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步更新文档类型
        /// </summary>
        /// <param name="dto">更新的文档类型DTO</param>
        [HttpPost]
        [Description("异步更新文档类型")]
        public async Task<AjaxResult> UpdateAsync([FromBody] DocumentTypeInputDto dto)
        {
            return (await _documentTypeService.UpdateAsync(dto)).ToAjaxResult();
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

    }
}
