using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IDataDictionnary
{
    public interface IDataDictionnaryServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(DataDictionnaryInputDto input);
    }
}
