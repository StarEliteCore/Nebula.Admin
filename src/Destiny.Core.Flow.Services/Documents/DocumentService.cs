



using System;
using Destiny.Core.Flow.Dtos;
using System.Threading.Tasks;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow;
using Destiny.Core.Flow.Enums;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Entities;
using Destiny.Core.Flow.IServices.Documents;
using Destiny.Core.Flow.Ui.Abstracts;
using Destiny.Core.Flow.Dtos.DocumentTypes;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Services.Documents
{
    /// <summary>
    ///文档
    /// </summary>
    public class DocumentService : IDocumentService
    {

        private readonly IRepository<Document, Guid> _documentRepository;

        /// <summary>
        /// 初始化一个<see cref="DocumentService"/>类型的新实例
        /// </summary>
        public DocumentService(IRepository<Document, Guid> documentRepository)
        {
            _documentRepository = documentRepository;
        }
        
        /// <summary>
        /// 异步创建文档
        /// </summary>
        /// <param name="dto">添加的文档DTO</param>
        public async Task<OperationResponse> CreateAsync(DocumentInputDto dto)
        {
            return await _documentRepository.InsertAsync(dto);
        }
        
        
        /// <summary>
        /// 异步更新文档
        /// </summary>
        /// <param name="dto">更新的文档DTO</param>
        public async Task<OperationResponse> UpdateAsync(DocumentInputDto dto)
        {
            return await _documentRepository.UpdateAsync(dto);
        }

        /// <summary>
        /// 异步加载表单文档
        /// </summary>
        /// <param name="id">要加载的文档主键</param>
        public async Task<OperationResponse<DocumentOutputDto>> LoadFormAsync(Guid id)
        {
            var dto = (await _documentRepository.GetByIdAsync(id)).MapTo<DocumentOutputDto>();
            return new OperationResponse<DocumentOutputDto>("加载成功",dto,OperationResponseType.Success);
        }
        
        /// <summary>
        /// 异步删除文档
        /// </summary>
        /// <param name="id">要删除的文档主键</param>
        public Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotEmpty(nameof(id));
            return _documentRepository.DeleteAsync(id);
        }
        
        /// <summary>
        /// 异步得到文档分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        public Task<IPagedResult<DocumentPageListDto>> GetPageAsync(PageRequest request)
        {
            return _documentRepository.Entities.ToPageAsync<Document,DocumentPageListDto>(request);
        }

       
    }
}
