using Destiny.Core.Flow.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{
   public static class DbContextOptionsBuilderExtenions
    {


        public static void MigrationsAssembly(this DbContextOptionsBuilder optionsBuilder, string migrationsAssemblyName)
        {
            if (!migrationsAssemblyName.IsNullOrEmpty())
            {
                optionsBuilder.MigrationsAssembly(migrationsAssemblyName);

            }
        }
    }
}
