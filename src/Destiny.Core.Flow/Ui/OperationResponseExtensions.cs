using Destiny.Core.Flow.Enums;

namespace Destiny.Core.Flow.Ui
{
    public static class OperationResponseExtensions
    {

        /// <summary>
        /// 成功
        /// </summary>
        public static OperationResponse<TData> Ok<TData>(this OperationResponse<TData> operation)
        {
            return operation.Ok<TData>(string.Empty, default(TData));
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        public static OperationResponse<TData> Ok<TData>(this OperationResponse<TData> operation, string message)
        {
            return operation.Ok<TData>(message, default(TData));
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse<TData> Ok<TData>(this OperationResponse<TData> operation, TData data)
        {
            return operation.Ok<TData>(string.Empty, data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse<TData> Ok<TData>(this OperationResponse<TData> operation, string message, TData data)
        {

            return new OperationResponse<TData>(message, data, OperationResponseType.Success);
        }



        public static OperationResponse<TData> Error<TData>(this OperationResponse<TData> operation, string message)
        {
            return operation.Error<TData>(message, default(TData));
        }
        public static OperationResponse<TData> Error<TData>(this OperationResponse<TData> operation, TData data)
        {
            return operation.Error(string.Empty, data);
        }
        public static OperationResponse<TData> Error<TData>(this OperationResponse<TData> operation, string message, TData data)
        {

            return new OperationResponse<TData>(message, data, OperationResponseType.Error);
        }


        /// <summary>
        /// 成功
        /// </summary>
        public static OperationResponse Ok(this OperationResponse response)
        {
            return response.Ok(string.Empty, null);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        public static OperationResponse Ok(this OperationResponse response, string message)
        {
            return response.Ok(message, null);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse Ok(this OperationResponse response, object data)
        {
            return response.Ok(string.Empty, data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse Ok(this OperationResponse response, string message, object data)
        {

            return new OperationResponse(message, data, OperationResponseType.Success);
        }



        public static OperationResponse Error(this OperationResponse response, string message)
        {
            return response.Error(message, null);
        }
        public static OperationResponse Error(this OperationResponse response, object data)
        {
            return response.Error(string.Empty, data);
        }
        public static OperationResponse Error(this OperationResponse response, string message, object data)
        {

            return new OperationResponse(message, data, OperationResponseType.Error);
        }
    }
}
