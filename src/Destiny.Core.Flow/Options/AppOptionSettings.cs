namespace Destiny.Core.Flow.Options
{
    public class AppOptionSettings
    {

        public AppOptionSettings()
        {

        }




        /// <summary>
        /// Jwt操作类
        /// </summary>
        public JwtOptions Jwt { get; set; }

        public CorsOptions Cors { get; set; }

        public AuthOptions Auth { get; set; }

        /// <summary>
        /// 是否自动添加功能
        /// </summary>
        public bool IsAutoAddFunction { get; set; }
    }
}
