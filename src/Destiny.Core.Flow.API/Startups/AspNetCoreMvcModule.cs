using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Options;
using Destiny.Core.Flow.Permission;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    public class AspNetCoreMvcModule: AppModuleBase
    {
        private string _corePolicyName = string.Empty;

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();
            services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));
            var settings = services.GetAppSettings();            
            if (!settings.Cors.PolicyName.IsNullOrEmpty() && !settings.Cors.Url.IsNullOrEmpty()) //添加跨域
            {
                _corePolicyName = settings.Cors.PolicyName;
                services.AddCors(c =>
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
            services.AddHttpContextAccessor();
            services.AddControllers(o => o.SuppressAsyncSuffixInActionNames = false)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });
            services.AddTransient<IPrincipal>(provider =>
            {
                IHttpContextAccessor accessor = provider.GetService<IHttpContextAccessor>();
                return accessor?.HttpContext?.User;
            });
            return services;
        }
        public override void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            if (!_corePolicyName.IsNullOrEmpty()) 
            {
                app.UseCors(_corePolicyName); //添加跨域中间件
            }
            app.UseAuthentication(); //认证
            app.UseAuthorization();//授权
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
