namespace Destiny.Core.Flow.Dtos
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ChangePassInputDto
    {
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