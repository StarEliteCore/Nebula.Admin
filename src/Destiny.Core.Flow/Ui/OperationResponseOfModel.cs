using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Filter;

namespace Destiny.Core.Flow.Ui
{
    /// <summary>
    /// 有重复代码想办法解决。。
    /// </summary>
    public class OperationResponse<TData> : ResultBase<TData>, IHasResultType<OperationResponseType>
    {

        public OperationResponse() : this(OperationResponseType.Success)
        {


        }
        public OperationResponse(OperationResponseType type = OperationResponseType.Success) : this("", default(TData), type)
        {


        }
        public OperationResponse(string message, OperationResponseType type) : this(message, default(TData), type)
        {


        }
        public OperationResponse(string message, TData data, OperationResponseType type)
        {
            Message = message;
            Type = type;
            Data = data;

        }





        public virtual OperationResponseType Type { get; set; }


        public override bool Success => Type == OperationResponseType.Success;



        /// <summary>
        /// 成功
        /// </summary>
        public static OperationResponse<TData> Ok()
        {
            return Ok(string.Empty, default(TData));
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        public static OperationResponse<TData> Ok(string message)
        {
            return Ok(message, default(TData));
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse<TData> Ok(TData data)
        {
            return Ok(string.Empty, data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse<TData> Ok(string message, TData data)
        {

            return new OperationResponse<TData>(message, data, OperationResponseType.Success);
        }



        public static OperationResponse<TData> Error(string message)
        {
            return Error(message, default(TData));
        }
        public static OperationResponse<TData> Error(TData data)
        {
            return Error(string.Empty, data);
        }
        public static OperationResponse<TData> Error(string message, TData data)
        {

            return new OperationResponse<TData>(message, data, OperationResponseType.Error);
        }




        public bool Exp()
        {
            return Type == OperationResponseType.Exp;
        }

    }
}
