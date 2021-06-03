using System;
using Destiny.Core.Flow.Dtos;
using System.Threading.Tasks;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using DestinyCore.Ui;
using DestinyCore.Extensions;
using Destiny.Core.Flow;
using DestinyCore.Enums;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Entities;
using Destiny.Core.Flow.IServices.Documents;
using DestinyCore.Ui.Abstracts;
using Destiny.Core.Flow.Dtos.DocumentTypes;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DestinyCore.ExpressionUtil;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Destiny.Core.Flow.Model.Entities.Identity;
using DestinyCore;

namespace Destiny.Core.Flow.Services.Documents
{
    /// <summary>
    ///文档
    /// </summary>
    public class DocumentService : IDocumentService
    {

        private readonly IRepository<Document, Guid> _documentRepository;
        private readonly IRepository<DocumentType, Guid> _documentTypeRepository;
        private readonly UserManager<User> _userManager = null;

        /// <summary>
        /// 初始化一个<see cref="DocumentService"/>类型的新实例
        /// </summary>
        public DocumentService(IRepository<Document, Guid> documentRepository, IRepository<DocumentType, Guid> documentTypeRepository, UserManager<User> userManager)
        {
            _documentRepository = documentRepository;
            _documentTypeRepository = documentTypeRepository;
            _userManager = userManager;
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
        public async Task<IPagedResult<DocumentPageListDto>> GetPageAsync(PageRequest request)
        {
            var filter=  FilterBuilder.GetExpression<Document>(request.Filter);  //这里可以分到分页里做
            var documents= await _documentRepository.Entities.ToPageAsync(filter,request,o=>new DocumentPageListDto() { 
            
                Id=o.Id,
                Title=o.Title,
                Content=o.Content,
                CreatedTime=o.CreatedTime,
                DocumentTypeId=o.DocumentTypeId,
                LastModifionTime=o.LastModifionTime,
                DocumentTypeName= _documentTypeRepository.Entities.Where(type=>type.Id==o.DocumentTypeId).Select(type=>type.Name).FirstOrDefault(),
                NickName=_userManager.Users.Where(u=>u.Id==o.CreatorUserId).Select(u=>u.NickName).FirstOrDefault()
                
            });
            return documents;
           
        }

       
    }
}
