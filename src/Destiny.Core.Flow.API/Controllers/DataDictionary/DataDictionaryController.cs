using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.IServices.IDataDictionnary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.API.Controllers.DataDictionary
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataDictionaryController : ControllerBase
    {
        private readonly IDataDictionnaryServices _dataDictionnaryServices  = null;

        public DataDictionaryController(IDataDictionnaryServices dataDictionnaryServices)
        {
            _dataDictionnaryServices = dataDictionnaryServices;
        }

        // GET: api/DataDictionary
        [HttpPost]
        public async Task<AjaxResult> Post([FromBody]DataDictionnaryInputDto dto)
        {
            return (await _dataDictionnaryServices.CreateAsync(dto)).ToAjaxResult();
        }
    }
}
