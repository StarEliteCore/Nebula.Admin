using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EntityFrameworkCore
{
    public class IdentityServer4DefaultDbContext : DbContextBase
    {
        public IdentityServer4DefaultDbContext(DbContextOptions<IdentityServer4DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {

        }

        protected override object OnBeforeSaveChanges()
        {
            //_logger.LogInformation($"进入IdentityServer4下上文开始保存更改方法");
            return null;
        }

        protected override void OnCompleted(int count, object sender)
        {
            //_logger.LogInformation($"进入IdentityServer4下上文保存更改成功方法");
        }
    }
}
