using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Events.EventBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow
{
    public class DefaultDbContext : DbContextBase
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        
    }
}