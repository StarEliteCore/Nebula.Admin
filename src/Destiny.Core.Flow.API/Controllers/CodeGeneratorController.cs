using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.CodeGenerator;
using Destiny.Core.Flow.Enums;
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
        private readonly ICodeGeneratorService _codeGeneratorService = null;

        public CodeGeneratorController(Destiny.Core.Flow.CodeGenerator.ICodeGenerator codeGenerator, ICodeGeneratorService codeGeneratorService)
        {
            _codeGenerator = codeGenerator;
            _codeGeneratorService = codeGeneratorService;
        }



        /// <summary>
        /// 代码生成
        /// </summary>
        [Description("代码生成")]
        [HttpPost]
        public AjaxResult GenerateCode([FromBody] ProjectMetadata projectMetadata)
        {

            _codeGenerator.GenerateCode(projectMetadata);
            return new AjaxResult("生成成功");
        }

        [Description("得到C#类型转成下拉项")]
        [HttpGet]
        public AjaxResult GetCSharpTypeToSelectItem()
        {
            var result = _codeGeneratorService.GetCSharpTypeToSelectItem();
            return result.ToAjaxResult();
        }

    }
}
