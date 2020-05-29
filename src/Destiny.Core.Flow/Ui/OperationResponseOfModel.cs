using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Ui
{
   public class OperationResponse<TData>: ResultBase<TData>, IHasResultType<OperationResponseType>
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
        /// 是否成功
        /// </summary>
        /// <param name="message"></param>
        public void IsSuccess(string message)
        {
            this.IsSuccess(message,default(TData));
        }
        public void IsSuccess(TData data)
        {
            this.IsSuccess(string.Empty,data);
        }

        public void IsSuccess(string message,TData data)
        {
            this.Type = OperationResponseType.Success;
            this.Message = message;
            this.Data = data;
        }




        public bool Error()
        {
            return Type != OperationResponseType.Success;
        }

        public bool Exp()
        {
            return Type == OperationResponseType.Exp;
        }
    }
}
