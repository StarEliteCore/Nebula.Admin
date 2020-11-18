using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.MenuFunction
{
    /// <summary>
    /// 批量添加菜单功能
    /// </summary>
   public  class BatchAddMenuFunctionInputDto
    {

        public Guid[] MenuIds { get; set; }

        public Guid[] FunctionIds { get; set; }
    }
}
