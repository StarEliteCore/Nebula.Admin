using System.ComponentModel.DataAnnotations;

namespace Destiny.Core.Flow.OpenIddictServer.ViewModels.Account
{
    /// <summary>
    /// 忘记密码ViewModel
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
