using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
  public  interface IFullAuditedEntity<TPrimaryKey>:ICreationAudited<TPrimaryKey>,IModificationAudited<TPrimaryKey>, ISoftDelete
     where   TPrimaryKey :struct
    {

        
    }



}
