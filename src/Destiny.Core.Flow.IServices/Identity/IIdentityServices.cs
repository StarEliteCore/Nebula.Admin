using AspectCore.DynamicProxy;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Dtos.Identitys;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Identity
{
    /// <summary>
    /// 身份接口
    /// </summary>

    public interface IIdentityServices: IScopedDependency
    {
        //[ServiceInterceptor(typeof(TransactionalAttribute))]
        Task<(OperationResponse item, Claim[] cliams)> Login(LoginDto loginDto);

        Task<(OperationResponse item, Claim[] cliams)> ChangePassword(ChangePassInputDto dto);


    }
}
