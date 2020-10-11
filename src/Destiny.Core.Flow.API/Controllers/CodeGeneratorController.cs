using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.CodeGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    [Description("代码生成器")]
    public class CodeGeneratorController : ApiControllerBase
    {

        private readonly Destiny.Core.Flow.CodeGenerator.ICodeGenerator _codeGenerator = null;

        public CodeGeneratorController(Destiny.Core.Flow.CodeGenerator.ICodeGenerator codeGenerator)
        {
            _codeGenerator = codeGenerator;
        }



        /// <summary>
        /// 代码生成(目前这样，等页面弄好，再修改)
        /// </summary>
        [Description("代码生成")]
        [HttpPost]
        public AjaxResult GenerateCode([FromBody] ProjectMetadata projectMetadata) {

            _codeGenerator.GenerateCode(projectMetadata);
            return new AjaxResult("生成成功");
        }

    }
}
