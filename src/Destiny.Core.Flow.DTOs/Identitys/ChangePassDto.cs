using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.Identitys
{
  public  class ChangePassDto
    {

        public string UserName { get; set; }
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

    }
}
