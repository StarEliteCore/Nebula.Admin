using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Ui;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Permission
{
    /// <summary>
    /// 权限验证接口
    /// </summary>
    public interface IAuthorityVerification : IScopedDependency
    {
        /// <summary>
        /// 判断用户是否有权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AuthorizationResult> IsPermission(string url);
    }
}
