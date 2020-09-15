namespace Destiny.Core.Flow.Dtos
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ChangePassInputDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>

        public string NewPassword { get; set; }

    }
}
