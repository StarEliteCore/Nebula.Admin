using Destiny.Core.Flow.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Ui
{
   public class OperationResponse<TData>: ResultBase
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



    


        public TData Data { get; set; }

        public OperationResponseType Type { get; set; }

   
        public override bool  Successed => Type == OperationResponseType.Success;

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
