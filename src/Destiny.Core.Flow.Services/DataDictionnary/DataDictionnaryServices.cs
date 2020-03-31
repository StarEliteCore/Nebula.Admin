using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.IDataDictionnary;
using Destiny.Core.Flow.Model.Entities.Dictionary;
using Destiny.Core.Flow.Repository.DictionaryRepository;
using Destiny.Core.Flow.Ui;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.DataDictionnary
{
    [Dependency(ServiceLifetime.Scoped)]
    public class DataDictionnaryServices: IDataDictionnaryServices
    {
        private readonly IDataDictionnaryRepository _dataDictionnaryRepository = null;
        public DataDictionnaryServices(IDataDictionnaryRepository dataDictionnaryRepository)
        {
            _dataDictionnaryRepository = dataDictionnaryRepository;
        }
        public async Task<OperationResponse> CreateAsync(DataDictionnaryInputDto input)
        {
            input.NotNull(nameof(input));
            var dictionnary = input.MapTo<DataDictionary>();
            var operationResponse = new OperationResponse("添加成功", Enums.OperationResponseType.Success);
            operationResponse.Success = await _dataDictionnaryRepository.InsertAsync(dictionnary) > 0;
            operationResponse.Message = operationResponse.Success ? "添加成功" : "添加失败";
            return operationResponse;
        }

    }
}
