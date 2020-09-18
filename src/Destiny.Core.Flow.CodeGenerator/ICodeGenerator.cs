using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.CodeGenerator
{
    /// <summary>
    /// 生成器
    /// </summary>
    public interface ICodeGenerator
    {
        /// <summary>
        /// 创建代码文件
        /// </summary>
        /// <param name="projectMetadata"></param>
        /// <param name="filePath"></param>

        void GenerateCode(ProjectMetadata projectMetadata, string filePath);

        /// <summary>
        /// 创建实体代码
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        CodeData GenerateEntityCode(ProjectMetadata metadata);
    }
}
