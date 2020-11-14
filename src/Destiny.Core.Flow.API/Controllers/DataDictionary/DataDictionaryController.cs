using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.IDataDictionnary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
namespace Destiny.Core.Flow.API.Controllers.DataDictionary
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Description("数据字典")]
    public class DataDictionaryController : AdminControllerBase
    {
        private readonly IDataDictionnaryServices _dataDictionnaryServices = null;
        public DataDictionaryController(IDataDictionnaryServices dataDictionnaryServices)
        {
            _dataDictionnaryServices = dataDictionnaryServices;
        }
        /// <summary>
        /// 分页获取数据字典
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("分页获取数据字典")]
        public async Task<PageList<DataDictionaryOutPageListDto>> GetPageListAsync([FromBody] PageRequest request)
        {
            return (await _dataDictionnaryServices.GetDictionnnaryPageAsync(request)).ToPageList();
        }
        /// <summary>
        /// 修改数据字典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("修改一个数据字典")]
        public async Task<AjaxResult> UpdateAsync(DataDictionnaryInputDto input)
        {
            return (await _dataDictionnaryServices.UpdateAsync(input)).ToAjaxResult();
        }
        /// <summary>
        /// 添加数据一个数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建数据字典")]
        [AuditLog]
        public async Task<AjaxResult> CreateAsync([FromBody] DataDictionnaryInputDto dto)
        {
            return (await _dataDictionnaryServices.CreateAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 根据Id删除数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("异步删除数据字典")]
        [HttpDelete]
        public async Task<AjaxResult> DeleteAsyc(Guid? id)
        {
            return (await _dataDictionnaryServices.DeleteAsync(id.Value)).ToAjaxResult();
        }

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Description("异步查询数据字典")]
        [HttpGet]
        public async Task<TreeModel<DataDictionaryOutDto>> GetTableAsync()
        {
            var result = await _dataDictionnaryServices.GetDictionnnaryAsync();

            return new TreeModel<DataDictionaryOutDto>
            {
                ItemList = result.ItemList,
                Message = result.Message,
                Success = result.Success
            };
        }
        /// <summary>
        /// 根据ID获取数据字典
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Description("根据id获取数据字典详情")]
        [HttpGet]
        public async Task<AjaxResult> GetDataDictionnnaryListAsync(Guid Id)
        {
            return (await _dataDictionnaryServices.GetLoadDictionnnary(Id)).ToAjaxResult();
        }
    }
}
