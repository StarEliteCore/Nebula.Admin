using System.ComponentModel.DataAnnotations;

namespace Destiny.Core.Flow.Dtos
{
    /// <summary>
    /// 登录Dto
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 用户名登录名
        /// </summary>

        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}