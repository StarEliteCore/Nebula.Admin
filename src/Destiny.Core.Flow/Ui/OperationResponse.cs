using Destiny.Core.Flow.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Ui
{
  public  class OperationResponse: OperationResponse<object>
    {
        public OperationResponse() : base(OperationResponseType.Success)
        {


        }
        public OperationResponse(OperationResponseType type = OperationResponseType.Success) : base("", null, type)
        {


        }
        public OperationResponse(string message, OperationResponseType type) : base(message, null, type)
        {


        }
        public OperationResponse(string message, object data, OperationResponseType type) : base(message, data, type)
        {
        }
    }
}
