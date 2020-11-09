using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace Destiny.Core.Flow.Swagger
{
    public class SwaggerModule : AppModule
    {



        private string _url = string.Empty;
        private string _title = string.Empty;

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            IConfiguration configuration = context.GetConfiguration();
            var title = configuration["Destiny:Swagger:Title"];
            var version = configuration["Destiny:Swagger:Version"];
            var url = configuration["Destiny:Swagger:Url"];

            if (url.IsNullOrEmpty())
            {
                throw new AppException("Url不能为空 ！！！");
            }

            if (version.IsNullOrEmpty())
            {
                throw new AppException("版本号不能为空 ！！！");
            }

            if (title.IsNullOrEmpty())
            {

                throw new AppException("标题不能为空 ！！！");
            }
            _url = url;
            _title = title;

            context.Services.AddSwaggerGen(s =>
            {


                s.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                var files = Directory.GetFiles(basePath, "*.xml");
                foreach (var file in files)
                {
                    s.IncludeXmlComments(file, true);
                }
                //s.OperationFilter<AddResponseHeadersFilter>();
                //
                // Use method name as operationId
                s.CustomOperationIds(apiDesc =>
                {
                    return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
                });
                // TODO:一定要返回true！
                s.DocInclusionPredicate((docName, description) =>
                {
                    return true;
                });

                ////https://github.com/domaindrivendev/Swashbuckle.AspNetCore  
                //s.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //s.OperationFilter<SecurityRequirementsOperationFilter>();  // 很重要！这里配置安全校验，和之前的版本不一样
                s.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",

                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {

                       new OpenApiSecurityScheme{
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                       },
                       new[] { "readAccess", "writeAccess" }
                    }
                });

                //s.SchemaFilter<AutoRestSchemaFilter>();
                //s.DocumentFilter<TagDescriptionsDocumentFilter>();


            });
        }



        public virtual Stream GetIndexStream()
        {

            return null;
        }

        public override void ApplicationInitialization(ApplicationContext context)
        {

            var app = context.GetApplicationBuilder();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                if (this.GetIndexStream() != null) {
                    c.IndexStream = ()=>this.GetIndexStream();
                }
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Example);
                c.DefaultModelsExpandDepth(-1);

                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                c.EnableDeepLinking();
                c.EnableFilter();
                c.MaxDisplayedTags(int.MaxValue);
                c.ShowExtensions();
                c.EnableValidator();

                c.SwaggerEndpoint(_url, _title);
                c.RoutePrefix = string.Empty;
            });
        }


    }
}
