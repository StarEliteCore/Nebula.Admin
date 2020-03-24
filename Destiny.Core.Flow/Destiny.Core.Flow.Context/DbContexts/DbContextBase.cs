
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Destiny.Core.Flow
{
   /// <summary>
   /// 上下文基类
   /// </summary>
    public abstract class DbContextBase : DbContext
    {
        private readonly IServiceProvider _serviceProvider = null;
   

        protected DbContextBase(DbContextOptions options,IServiceProvider serviceProvider)
             : base(options)
        {
            _serviceProvider = serviceProvider;

            //_logger = serviceProvider?.GetLogger(GetType());
           
        }

        public IUnitOfWork UnitOfWork { get; set; }





        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
    
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
