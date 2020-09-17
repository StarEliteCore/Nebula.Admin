using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Ui;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Identity
{
    /// <summary>
    /// 身份接口
    /// </summary>

    public interface IIdentityServices : IScopedDependency
    {
        //[ServiceInterceptor(typeof(TransactionalAttribute))]
        Task<(OperationResponse item, Claim[] cliams)> Login(Dtos.LoginDto loginDto);

        Task<(OperationResponse item, Claim[] cliams)> ChangePassword(Dtos.ChangePassInputDto dto);
    }
}