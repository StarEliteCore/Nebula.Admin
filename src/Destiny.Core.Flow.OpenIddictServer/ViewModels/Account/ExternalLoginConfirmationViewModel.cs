using System.ComponentModel.DataAnnotations;

namespace Destiny.Core.Flow.OpenIddictServer.ViewModels.Account
{
    /// <summary>
    /// 外部登录确认ViewModel
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
