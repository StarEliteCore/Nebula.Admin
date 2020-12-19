using Destiny.Core.Flow.AspNetCore.Module;
using Destiny.Core.Flow.AspNetCore.Mvc.Filters;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    [DependsOn(typeof(AspNetCoreModule))]
    public class MvcModule: MvcModuleBase
    {
        private string _corePolicyName = string.Empty;
        protected override void AddCors(ConfigureServicesContext context)
        {
            var settings= context.Services.GetObject<AppOptionSettings>();
            if (!settings.Cors.PolicyName.IsNullOrEmpty() && !settings.Cors.Url.IsNullOrEmpty())
            {

                _corePolicyName = settings.Cors.PolicyName;
                context.Services.AddCors(c =>
                {
                    c.AddPolicy(settings.Cors.PolicyName, policy =>
                    {
                        policy.WithOrigins(settings.Cors.Url
                          .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
                        //policy.WithOrigins("http://localhost:5001")//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                        .AllowAnyHeader().AllowAnyMethod().AllowCredentials();//允许cookie;
                    });
                });
            }
        }


        protected override void AddMvcOptions(MvcOptions options)
        {
            options.SuppressAsyncSuffixInActionNames = false;
            options.Filters.Add<PermissionAuthorizationFilter>();
            //options.Filters.Add<AuditLogFilter>();
        }
        protected override void UseCors(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            if (!_corePolicyName.IsNullOrEmpty())
            {
                app.UseCors(_corePolicyName); //添加跨域中间件
            }
        }
    }
}
