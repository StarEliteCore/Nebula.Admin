using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Destiny.Core.Flow.OpenIddictServer.ViewModels.Account
{
    /// <summary>
    /// 发送验证码ViewModel
    /// </summary>
    public class SendCodeViewModel
    {
        /// <summary>
        /// 已选择提供器
        /// </summary>
        public string SelectedProvider { get; set; }

        /// <summary>
        /// 提供器列表
        /// </summary>
        public ICollection<SelectListItem> Providers { get; set; }

        /// <summary>
        /// 返回url
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 记住我
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
