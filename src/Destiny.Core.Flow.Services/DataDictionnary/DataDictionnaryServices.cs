using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices.IDataDictionnary;
using Destiny.Core.Flow.Model.Entities.Dictionary;
using Destiny.Core.Flow.Repository.DictionaryRepository;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.DataDictionnary
{
    public class DataDictionnaryServices : IDataDictionnaryServices
    {
        private readonly IDataDictionnaryRepository _dataDictionnaryRepository = null;

        public DataDictionnaryServices(IDataDictionnaryRepository dataDictionnaryRepository)
        {
            _dataDictionnaryRepository = dataDictionnaryRepository;
        }

        public async Task<OperationResponse> CreateAsync(DataDictionnaryInputDto input)
        {
            input.NotNull(nameof(input));
            var response = await _dataDictionnaryRepository.InsertAsync(input);
            //var dictionnary = input.MapTo<DataDictionary>();
            //var operationResponse = new OperationResponse("添加成功", Enums.OperationResponseType.Success);
            //operationResponse.Success = await _dataDictionnaryRepository.InsertAsync(dictionnary) > 0;
            //operationResponse.Message = operationResponse.Success ? "添加成功" : "添加失败";
            return response;
        }

        public async Task<OperationResponse> UpdateAsync(DataDictionnaryInputDto input)
        {
            input.NotNull(nameof(input));
            var result = await _dataDictionnaryRepository.UpdateAsync(input);
            return result;
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _dataDictionnaryRepository.DeleteAsync(id);
        }

        public async Task<IPagedResult<DataDictionaryOutPageListDto>> GetDictionnnaryPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            return await _dataDictionnaryRepository.TrackEntities.ToPageAsync<DataDictionaryEntity, DataDictionaryOutPageListDto>(request);
        }

        public async Task<TreeResult<DataDictionaryOutDto>> GetDictionnnaryAsync()
        {
            return await _dataDictionnaryRepository.Entities.ToTreeResultAsync<DataDictionaryEntity, DataDictionaryOutDto>(
                (p, c) =>
                {
                    return c.ParentId == null || c.ParentId == Guid.Empty;
                },
                (p, c) =>
                {
                    return p.Id == c.ParentId;
                },
                (p, children) =>
                {
                    if (p.children == null)
                    {
                        p.children = new List<DataDictionaryOutDto>();
                    }
                    p.children.AddRange(children);
                }
                );
        }

        /// <summary>
        /// 根据ID获取一个数据字典
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<OperationResponse<DataDictionnaryLoadDto>> GetLoadDictionnnary(Guid Id)
        {
            var data = await _dataDictionnaryRepository.GetByIdAsync(Id);
            var dataDto = data.MapTo<DataDictionnaryLoadDto>();
            return new OperationResponse<DataDictionnaryLoadDto>(MessageDefinitionType.LoadSucces, dataDto, OperationResponseType.Success);
        }
    }
}