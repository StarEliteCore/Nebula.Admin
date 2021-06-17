using Destiny.Core.Flow.OpenIddict.EntityFrameworkCore;
using DestinyCore.Dependency;
using DestinyCore.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Linq;

namespace Destiny.Core.Flow.OpenIddictServer.EntityFrameworkCore
{
    //public class OpenIddictDbContextFactory : IDesignTimeDbContextFactory<OpenIddictEntityDefaultDbContext>
    //{
    //    public OpenIddictEntityDefaultDbContext CreateDbContext(string[] args)
    //    {
    //        //var options = IocManage.Instance.GetService<AppOptionSettings>();
    //        //var connection = options.DbContexts.Values.First().ConnectionString;
    //        var buidler = new DbContextOptionsBuilder<OpenIddictEntityDefaultDbContext>()
    //            .UseMySql("server=47.100.213.49;userid=test;pwd=pwd123456;database=Destiny.Core.Flow;connectiontimeout=3000;port=3307;Pooling=true;Max Pool Size=300; Min Pool Size=5;", new MySqlServerVersion(new Version(8, 0, 21)), options => options.MigrationsAssembly("Destiny.Core.Flow.OpenIddictServer"));
    //        return null;
    //        //return new OpenIddictEntityDefaultDbContext(buidler.Options);
    //    }
    //}
}
