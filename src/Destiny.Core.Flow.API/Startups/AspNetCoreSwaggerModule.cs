﻿using DestinyCore.Exceptions;
using DestinyCore.Extensions;
using DestinyCore.Modules;
using DestinyCore.Swagger;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    public class AspNetCoreSwaggerModule: SwaggerModule
    {


        public override Stream GetIndexStream()
        {

            return GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Destiny.Core.Flow.API.index.html");
        }

    }
}
