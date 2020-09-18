using Destiny.Core.Flow.Exceptions;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.CodeGenerator
{
    /// <summary>
    /// Razor引擎生成器
    /// </summary>
    public class RazorCodeGenerator: ICodeGenerator
    {



        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="projectMetadata"></param>
        /// <param name="filePath"></param>
        public void GenerateCode(ProjectMetadata projectMetadata, string filePath)
        {

            List<CodeData> codes = new List<CodeData>();

            codes.Add(GenerateEntityCode(projectMetadata));

            codes = codes.OrderBy(o => o.FileName).ToList();
            foreach (var code in codes)
            {
                var saveFilePath = $"{Path.Combine(@"{0}\{1}", filePath, code.FileName)}";
                var  path = Path.GetDirectoryName(saveFilePath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (var fs = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write))
                {
                    //实例化一个StreamWriter-->与fs相关联
                    using (var sw = new StreamWriter(fs))
                    {
                        //开始写入
                        sw.Write(code.SourceCode);
                        //清空缓冲区
                        sw.Flush();
                        //关闭流
                        sw.Close();
                        fs.Close();
                    }
                }
            }
        }

        private string GetTemplateCode(ProjectMetadata metadata, CodeType codeType)
        {
         

            string template = GetInternalTemplate(codeType);
            var key = GetKey(codeType, template);
            string code;
            code = Engine.Razor.RunCompile(template, key, metadata.GetType(), metadata);
            return code;
        }

        /// <summary>
        /// 创建键
        /// </summary>
        /// <param name="codeType"></param>
        /// <param name="template"></param>
        /// <returns></returns>

        private ITemplateKey GetKey(CodeType codeType, string template)
        {

            string name = $"{codeType.ToString()}-{Guid.NewGuid()}";
            return Engine.Razor.GetKey(name);
        }


        public CodeData GenerateEntityCode(ProjectMetadata metadata)
        {
            var template = GetTemplateCode(metadata, CodeType.Entity);
            var code = new CodeData()
            {
                SourceCode = template,
                FileName = $"Entity/{metadata.EntityMetadata.EntityName}.cs"
            };
            return code;
        }
        /// <summary>
        /// 读取指定代码类型的内置代码模板
        /// </summary>
        /// <param name="type">代码类型</param>
        /// <returns></returns>
        private string GetInternalTemplate(CodeType type)
        {
            String projectName = Assembly.GetExecutingAssembly().GetName().Name.ToString();
            string resName = $"{projectName}.Templates.{type.ToString()}.cshtml";
            Stream stream = GetType().Assembly.GetManifestResourceStream(resName);
            if (stream == null)
            {
                throw new AppException("没有找到对应的模板");
            }
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

    }

    public enum CodeType
    {
        /// <summary>
        /// 实体类
        /// </summary>
        Entity,

        
        /// <summary>
        /// 实体配置
        /// </summary>
        EntityConfiguration,

    }
}
