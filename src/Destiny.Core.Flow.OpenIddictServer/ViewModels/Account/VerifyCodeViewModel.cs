using System.ComponentModel.DataAnnotations;

namespace Destiny.Core.Flow.OpenIddictServer.ViewModels.Account
{
    /// <summary>
    /// 确认验证码ViewModel
    /// </summary>
    public class VerifyCodeViewModel
    {
        /// <summary>
        /// 提供器
        /// </summary>
        [Required]
        public string Provider { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// 返回url
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 记住此浏览器
        /// </summary>
        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        /// <summary>
        /// 记住我
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
