



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
using Destiny.Core.Flow.IServices.DocumentTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Destiny.Core.Flow.Services.DocumentTypes
{
    /// <summary>
    ///文档类型
    /// </summary>
    public class DocumentTypeService : IDocumentTypeService
    {

        private readonly IRepository<DocumentType, Guid> _documentTypeRepository;

        /// <summary>
        /// 初始化一个<see cref="DocumentTypeService"/>类型的新实例
        /// </summary>
        public DocumentTypeService(IRepository<DocumentType, Guid> documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }
        
        /// <summary>
        /// 异步创建文档类型
        /// </summary>
        /// <param name="dto">添加的文档类型DTO</param>
        public async Task<OperationResponse> CreateAsync(DocumentTypeInputDto dto)
        {
            return await _documentTypeRepository.InsertAsync(dto,async (d)=> {

                var isExist = await _documentTypeRepository.Entities.Where(o => o.Name == d.Name).AnyAsync();
                if (isExist)
                {
                    OperationResponse.Error("创建失败，该名字已存在！！");
                }
            
            });
        }
        
        
        /// <summary>
        /// 异步更新文档类型
        /// </summary>
        /// <param name="dto">更新的文档类型DTO</param>
        public async Task<OperationResponse> UpdateAsync(DocumentTypeInputDto dto)
        {
            return await _documentTypeRepository.UpdateAsync(dto);
        }

        /// <summary>
        /// 异步加载表单文档类型
        /// </summary>
        /// <param name="id">要加载的文档类型主键</param>
        public async Task<OperationResponse<DocumentTypeOutputDto>> LoadFormAsync(Guid id)
        {
            var dto = (await _documentTypeRepository.GetByIdAsync(id)).MapTo<DocumentTypeOutputDto>();
            return new OperationResponse<DocumentTypeOutputDto>("加载成功",dto,OperationResponseType.Success);
        }
        
        /// <summary>
        /// 异步删除文档类型
        /// </summary>
        /// <param name="id">要删除的文档类型主键</param>
        public Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotEmpty(nameof(id));
            return _documentTypeRepository.DeleteAsync(id);
        }
        
        /// <summary>
        /// 异步得到文档类型分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        public Task<IPagedResult<DocumentTypePageListDto>> GetPageAsync(PageRequest request)
        {
            return _documentTypeRepository.Entities.ToPageAsync<DocumentType,DocumentTypePageListDto>(request);
        }
    }
}
