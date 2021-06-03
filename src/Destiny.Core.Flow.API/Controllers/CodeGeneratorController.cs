using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DestinyCore.AspNetCore.Api;
using DestinyCore.AspNetCore;
using DestinyCore.Audit;
using DestinyCore.CodeGenerator;
using DestinyCore.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    [Description("代码生成器")]
    [DisableAuditing]
    public class CodeGeneratorController : ApiControllerBase
    {

        private readonly DestinyCore.CodeGenerator.ICodeGenerator _codeGenerator = null;
        private readonly ICodeGeneratorService _codeGeneratorService = null;

        public CodeGeneratorController(DestinyCore.CodeGenerator.ICodeGenerator codeGenerator, ICodeGeneratorService codeGeneratorService)
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
