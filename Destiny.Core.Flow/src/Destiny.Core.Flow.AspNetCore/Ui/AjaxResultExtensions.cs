
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;


using System;
using System.Collections.Generic;
using System.Text;

namespace MNZ.CMS.Core.AspNetCore.Ui
{
   public static class AjaxResultExtensions
    {
        public static AjaxResult ToAjaxResult(this OperationResponse operationResponse)
        {
            var message = operationResponse.Message ?? operationResponse.Type.ToDescription();
            AjaxResultType type = operationResponse.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResponse.Data) { Success = operationResponse.Successed };
        }

        public static AjaxResult ToAjaxResult<T>(this OperationResponse<T> operationResult)
        {
            var message = operationResult.Message ?? operationResult.Type.ToDescription();
            AjaxResultType type = operationResult.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResult.Data) { Success = operationResult.Successed };
        }

        public static AjaxResultType ToAjaxResultType(this OperationResponseType responseType)
        {
            return responseType switch
            {
                OperationResponseType.Success => AjaxResultType.Success,
                OperationResponseType.NoChanged => AjaxResultType.Info,
                _ => AjaxResultType.Error,
            };
        }
    }
}
