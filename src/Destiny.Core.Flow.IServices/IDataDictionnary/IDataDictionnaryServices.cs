using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IDataDictionnary
{
    public interface IDataDictionnaryServices : IScopedDependency
    {
        /// <summary>
        /// 创建一个数据字典
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(DataDictionnaryInputDto input);

        /// <summary>
        /// 分页查询数据字典
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<DataDictionaryOutPageListDto>> GetDictionnnaryPageAsync(PageRequest request);

        /// <summary>
        /// 修改数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(DataDictionnaryInputDto input);

        /// <summary>
        /// 删除一个数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 查询数据字典
        /// </summary>
        /// <returns></returns>
        Task<TreeResult<DataDictionaryOutDto>> GetDictionnnaryAsync();

        /// <summary>
        /// 根据ID获取一个数据字典
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OperationResponse<DataDictionnaryLoadDto>> GetLoadDictionnnary(Guid Id);
    }
}