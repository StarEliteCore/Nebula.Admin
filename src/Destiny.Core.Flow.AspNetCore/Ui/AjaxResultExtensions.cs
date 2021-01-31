using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
    public static class AjaxResultExtensions
    {
        public static AjaxResult ToAjaxResult(this OperationResponse operationResponse)
        {
            var message = operationResponse.Message ?? operationResponse.Type.ToDescription();
            AjaxResultType type = operationResponse.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResponse.Data) { Success = operationResponse.Success };
        }

        public static async Task<AjaxResult> ToAjaxResult(this Task<OperationResponse> operationResponse)
        {

            var result = await operationResponse;
            var message = result.Message ?? result.Type.ToDescription();
            AjaxResultType type = result.Type.ToAjaxResultType();
            return new AjaxResult(message, type, result.Data) { Success = result.Success };
        }

        public static AjaxResult ToAjaxResult<T>(this OperationResponse<T> operationResult)
        {
            var message = operationResult.Message ?? operationResult.Type.ToDescription();
            AjaxResultType type = operationResult.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResult.Data) { Success = operationResult.Success };
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

        public static AjaxResultType ToAjaxResultType(this AuthResultType type)
        {
            return type switch
            {
                AuthResultType.Success => AjaxResultType.Success,
                AuthResultType.Unauthorized => AjaxResultType.Unauthorized,
                AuthResultType.NoFound => AjaxResultType.NoFound,
                AuthResultType.Uncertified => AjaxResultType.Uncertified,
                _ => AjaxResultType.Uncertified,
            };
        }


        public static AjaxResult ToAjaxResult(this AuthorizationResult result)
        {


            var message = result.Message ?? result.Type.ToDescription();
            AjaxResultType type = result.Type.ToAjaxResultType();
            return new AjaxResult(message, type) { Success = result.Success };
        }
    }
}