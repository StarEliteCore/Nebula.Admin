using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Destiny.Core.Flow.CodeGenerator
{
    /// <summary>
    /// 生成器服务实现 
    /// </summary>
    public class CodeGeneratorService : ICodeGeneratorService
    {

        /// <summary>
        /// 得到C#类型转成下拉项
        /// </summary>
        /// <returns></returns>
        public OperationResponse GetCSharpTypeToSelectItem()
        {
          var item=  TypeHelper.GetCSharpType().Select(o =>new 
            {
                Label = o.Key.FullName,
                Value=o.Value,
            });
            return OperationResponse.Ok(data:item);
        }
    }
}
