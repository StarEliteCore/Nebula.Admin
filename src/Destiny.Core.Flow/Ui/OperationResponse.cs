using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Filter;

namespace Destiny.Core.Flow.Ui
{
    /// <summary>
    /// 有重复代码想办法解决。。
    /// </summary>
    public class OperationResponse : ResultBase<object>, IHasResultType<OperationResponseType>
    {

        public OperationResponse() : this(OperationResponseType.Success)
        {


        }
        public OperationResponse(OperationResponseType type = OperationResponseType.Success) : this("", null, type)
        {


        }
        public OperationResponse(string message, OperationResponseType type) : this(message, null, type)
        {


        }
        public OperationResponse(string message, object data, OperationResponseType type)
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
        public static OperationResponse Ok()
        {
            return Ok(string.Empty, null);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        public static OperationResponse Ok(string message)
        {
            return Ok(message, null);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse Ok(object data)
        {
            return Ok(string.Empty, data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">提示消息</param>
        /// <param name="data">返回成功数据</param>
        /// <returns></returns>
        public static OperationResponse Ok(string message, object data)
        {

            return new OperationResponse(message, data, OperationResponseType.Success);
        }



        public static OperationResponse Error(string message)
        {
            return Error(message, null);
        }
        public static OperationResponse Error(object data)
        {
            return Error(string.Empty, data);
        }
        public static OperationResponse Error(string message, object data)
        {

            return new OperationResponse(message, data, OperationResponseType.Error);
        }

    }
}
