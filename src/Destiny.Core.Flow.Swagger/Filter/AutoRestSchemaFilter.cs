using Destiny.Core.Flow.Extensions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Swagger.Filter
{
   
    
    public class AutoRestSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            //var type = context.Type;
            //if (type.IsEnum)
            //{
            //    schema.Extensions.Add(
            //        "x-ms-enum",
            //        new OpenApiObject
            //        {
            //            ["name"] = new OpenApiString(type.ToDescription()),
            //            ["modelAsString"] = new OpenApiBoolean(false),
            //            ["values"] = new OpenApiString("[{ value: \"dfdf\", description: \"3434\", name: \"1\" }]")
            //        }
            //    );
            //};
        }
    }
}
