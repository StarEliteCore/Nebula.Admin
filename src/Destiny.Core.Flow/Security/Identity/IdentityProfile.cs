using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Security.Identity
{
  public  class IdentityProfile
    {
       public string UserName { get; set; }

       public string UserId { get; set; }

       public bool IsSystem { get; set; }

       public bool IsAdmin { get;set; }

       public string[] RoleIds { get; set; }


       public string NickName { get; set; }







    }
}
