using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{

    [AttributeUsage(AttributeTargets.Class)]
    public   class DatabaseTypeAttribute: Attribute
    {
        public DatabaseTypeAttribute(DatabaseType databaseType)
        {

            DatabaseType = databaseType;


        }

        public DatabaseType DatabaseType { get; private set; }
    }
}
