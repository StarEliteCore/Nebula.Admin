using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Helpers;
using Destiny.Core.Flow.Ui;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
    /// <summary>
    /// Ajax操作结果
    /// </summary>
    public class AjaxResult: ResultBase<object>, IHasResultType<AjaxResultType>
    {
        public AjaxResult() : this(null)
        {
        }

        public AjaxResult(AjaxResultType type = AjaxResultType.Success) : this("", null, type)
        {
        }

        public AjaxResult(string message, AjaxResultType type = AjaxResultType.Success, object data = null) : this(message, data, type)
        {
        }

        public AjaxResult(AjaxResultType type = AjaxResultType.Success, object data = null) : this("", data, type)
        {
        }


        public AjaxResult(string message, object data, AjaxResultType type)
        {
            this.Message = message;
            this.Data = data;
            this.Type = type;
            this.Success = Succeeded();
        }

        public AjaxResult(string message, bool success, object data, AjaxResultType type)
        {
            this.Message = message;
            this.Data = data;
            this.Type = type;
            this.Success = success;
           
        }

     

        /// <summary>
        /// 返回类型
        /// </summary>

        public AjaxResultType Type { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Succeeded()
        {
            return Type == AjaxResultType.Success;
        }

        /// <summary>
        /// 是否错误
        /// </summary>
        public bool Error()
        {
            return Type == AjaxResultType.Error;
        }

        /// <summary>
        /// 转成对象
        /// </summary>
        /// <returns></returns>
        public object ToObject()
        {
            return new { Data, Message, Success, Type };
        }

        /// <summary>
        /// 转成JSON
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return this.ToObject().ToJson();
        }
    }
}