using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.CodeGenerator
{
    /// <summary>
    /// 生成器服务
    /// </summary>
    public interface ICodeGeneratorService
    {

        /// <summary>
        /// 得到C#类型转换下拉项
        /// </summary>
        /// <returns></returns>
        OperationResponse GetCSharpTypeToSelectItem();
    }
}
