using System.ComponentModel.DataAnnotations;

namespace Destiny.Core.Flow.OpenIddictServer.ViewModels
{
    /// <summary>
    /// 验证viewModel
    /// </summary>
    public class AuthorizeViewModel
    {
        /// <summary>
        /// 应用名
        /// </summary>
        [Display(Name = "Application")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// 授权范围
        /// </summary>
        [Display(Name = "Scope")]
        public string Scope { get; set; }
    }
}
