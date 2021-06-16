using DestinyCore.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Permission
{
    public interface IAuthorityService
    {
        Task<AuthorizationResult> IsPermission(string url);
    }
}
