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
using Destiny.Core.Flow.IServices.Documents;
namespace Destiny.Core.Flow.API.Controllers
{

    ///<summary>
    ///文档
    ///</summary>
    [Description("文档")]
    public class DocumentController : AdminControllerBase
    {

        private readonly IDocumentService _documentService;
        
        public DocumentController(IDocumentService documentService)
        {
            _documentService=documentService;
        }


        /// <summary>
        /// 异步创建文档
        /// </summary>
        /// <param name="dto">添加的文档DTO</param>
        [HttpPost]
        [Description("异步创建文档")]
        public async Task<AjaxResult> CreateAsync([FromBody] DocumentInputDto dto)
        {
            return (await _documentService.CreateAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步更新文档
        /// </summary>
        /// <param name="dto">更新的文档DTO</param>
        [HttpPost]
        [Description("异步更新文档")]
        public async Task<AjaxResult> UpdateAsync([FromBody] DocumentInputDto dto)
        {
            return (await _documentService.UpdateAsync(dto)).ToAjaxResult();
        }
        
        /// <summary>
        /// 异步加载表单文档
        /// </summary>
        /// <param name="id">要加载的文档主键</param>
        [HttpGet]
        [Description("异步加载表单文档")]
        public async Task<AjaxResult>  LoadFormAsync(Guid id)
        {
            return (await _documentService.LoadFormAsync(id)).ToAjaxResult();
        }
        
        
        /// <summary>
        /// 异步删除文档
        /// </summary>
        /// <param name="id">要删除的文档主键</param>
        [HttpDelete]
        [Description("异步删除文档")]
        public async Task<AjaxResult> DeleteAsync(Guid id)
        {
            return (await _documentService.DeleteAsync(id)).ToAjaxResult();
        }
        
        /// <summary>
        /// 异步得到文档分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        [HttpPost]
        [Description("异步得到文档分页数据")]
        public async Task<PageList<DocumentPageListDto>> GetPageAsync(PageRequest request)
        {
            return (await _documentService.GetPageAsync(request)).ToPageList();
        }

    }
}
