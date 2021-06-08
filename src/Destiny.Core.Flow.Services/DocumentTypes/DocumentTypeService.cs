



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
using Destiny.Core.Flow.IServices.DocumentTypes;
using System.Linq;
using DestinyCore.Exceptions;
using DestinyCore.Ui.Abstracts;
using Destiny.Core.Flow.Dtos.DocumentTypes;
using System.Collections.Generic;
using DestinyCore;

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
        public async Task<OperationResponse> CreateAsync(AssetInputDto dto)
        {
            return await _documentTypeRepository.InsertAsync(dto, async (d) => {
                MessageBox.ShowIf($"创建失败，此{dto.Name}名字已存在！！",await _documentTypeRepository.ExistAsync(o => o.Name == d.Name));

            });
        }


        /// <summary>
        /// 异步更新文档类型
        /// </summary>
        /// <param name="dto">更新的文档类型DTO</param>
        public async Task<OperationResponse> UpdateAsync(AssetInputDto dto)
        {
            return await _documentTypeRepository.UpdateAsync(dto, async (d, e) => {
                MessageBox.ShowIf($"更新失败，此{dto.Name}名字已存在！！", await _documentTypeRepository.ExistAsync(ee => ee.Id != d.Id && ee.Name == d.Name));

            });
        }

        /// <summary>
        /// 异步加载表单文档类型
        /// </summary>
        /// <param name="id">要加载的文档类型主键</param>
        public async Task<OperationResponse<AssetOutputDto>> LoadFormAsync(Guid id)
        {
            var dto = (await _documentTypeRepository.GetByIdAsync(id)).MapTo<AssetOutputDto>();
            return new OperationResponse<AssetOutputDto>("加载成功", dto, OperationResponseType.Success);
        }

        /// <summary>
        /// 异步删除文档类型
        /// </summary>
        /// <param name="id">要删除的文档类型主键</param>
        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotEmpty(nameof(id));


            return await _documentTypeRepository.DeleteAsync(id, async e=> {
                MessageBox.ShowIf("已存在下一级，无法删除，请先把下一级删除后，再删除！！！", await _documentTypeRepository.ExistAsync(e => e.ParentId == id));
            });
        }

        /// <summary>
        /// 异步得到文档类型分页数据
        /// </summary>
        /// <param name="request">分页请求数据</param>
        public Task<IPagedResult<AssetPageListDto>> GetPageAsync(PageRequest request)
        {

            return _documentTypeRepository.Entities.ToPageAsync<DocumentType, AssetPageListDto>(request);
        }


        /// <summary>
        /// 异步创建或者更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<OperationResponse> CreateOrUpdateAsync(AssetInputDto dto)
        {

            if (dto.Id == Guid.Empty)
            {
                return this.CreateAsync(dto);
            }
            return this.UpdateAsync(dto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ITreeResult<DocumentTreeOutDto>> GetTreeDataAsync()
        {
            return await _documentTypeRepository.Entities.OrderBy(o=>o.Sort).ToTreeResultAsync<DocumentType, DocumentTreeOutDto>((p, c) =>
            {
                return c.ParentId == null || c.ParentId == Guid.Empty;
            },
              (p, c) =>
              {
                  return p.Id == c.ParentId;
              },
              (p, children) =>
              {
                  if (p.Children == null)
                      p.Children = new List<DocumentTreeOutDto>();
                  p.Children.AddRange(children);
              });
        }

    }
}
