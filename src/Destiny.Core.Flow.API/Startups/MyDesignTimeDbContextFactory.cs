using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Interceptor;
using Destiny.Core.Flow.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    //public class MyDesignTimeDbContextFactory: IDesignTimeDbContextFactory<DbContext>
    //{

    //    public MyDesignTimeDbContextFactory(IServiceProvider serviceProvider)
    //    {
    //        _serviceProvider = serviceProvider;
    //    }

    //    private IServiceProvider _serviceProvider { get; set; }
    //    public DbContext CreateDbContext(string[] args)
    //    {
    //        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<DefaultDbContext>();
    //        optionsBuilder = DbContextOptionsBuilder(_serviceProvider, optionsBuilder);
    //        DefaultDbContext context = (DefaultDbContext)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(DefaultDbContext), builder.Options);

    //        return context;
    //    }

    //    public DbContextOptionsBuilder DbContextOptionsBuilder(IServiceProvider provider, DbContextOptionsBuilder optionsBuilder)
    //    {
    //        var type = typeof(DefaultDbContext);
    //        var settings = provider.GetAppSettings();
    //        if (settings == null)
    //        {
    //            MessageBox.Show("配置不存在!!");
    //        }

    //        DestinyContextOptions contextOptions = settings.DbContexts?.Values.FirstOrDefault(o => o.DbContextType == type);

    //        if (contextOptions is null)
    //        {
    //            MessageBox.Show($"无法找到{type.Name}数据库配置信息!!");

    //        }

    //        var databaseType = contextOptions.DatabaseType;

    //        var drivenProviderType = provider.GetServices<IDbContextDrivenProvider>()?.FirstOrDefault(o => o.GetType() ==);

    //        if (drivenProviderType == null)
    //        {
    //            MessageBox.Show($"没有找到{databaseType}类型的驱动实例");

    //        }

    //        var drivenProvider = (IDbContextDrivenProvider)provider.GetService(drivenProviderType);
    //        if (drivenProvider == null)
    //        {
    //            MessageBox.Show($"没有找到{databaseType}类型的驱动");

    //        }
    //        DestinyContextOptionsBuilder optionsBuilder1 = new DestinyContextOptionsBuilder();
    //        optionsBuilder1.MigrationsAssemblyName = contextOptions.MigrationsAssemblyName;
    //        var connectionString = contextOptions.ConnectionString;

    //        if (contextOptions.ConnectionString.IsFile(".txt")) //txt文件
    //        {

    //            connectionString = provider.GetFileText(contextOptions.ConnectionString, $"未找到存放{databaseType.ToDescription()}数据库链接的文件");
    //        }

    //        optionsBuilder = drivenProvider.Builder(optionsBuilder, connectionString, optionsBuilder1);

    //        optionsBuilder.AddInterceptors(new AuditInterceptor(provider));
    //        return optionsBuilder;
    //    }
    //}
}
