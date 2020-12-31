using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
   public static class JsonResultExtensions
    {

        /// <summary>
        /// 转成JsonResult
        /// </summary>
        /// <param name="action"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IActionResult ToJsonResult(this IActionResult action, AjaxResult result)
        {

            return new JsonResult(result);
        }
    }
}
