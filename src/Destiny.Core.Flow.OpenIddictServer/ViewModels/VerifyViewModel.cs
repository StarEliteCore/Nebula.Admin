using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OpenIddict.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Destiny.Core.Flow.OpenIddictServer.ViewModels
{
    /// <summary>
    /// 设备验证viewModel
    /// </summary>
    public class VerifyViewModel
    {
        /// <summary>
        /// 应用名
        /// </summary>
        [Display(Name = "Application")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// 错误
        /// </summary>
        [BindNever, Display(Name = "Error")]
        public string Error { get; set; }

        /// <summary>
        /// 错误详情
        /// </summary>
        [BindNever, Display(Name = "Error description")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// 授权范围
        /// </summary>
        [Display(Name = "Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 用户码
        /// </summary>
        [FromQuery(Name = OpenIddictConstants.Parameters.UserCode)]
        [Display(Name = "User code")]
        public string UserCode { get; set; }
    }
}
