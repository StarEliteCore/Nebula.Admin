using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
    public class ApiResourceOutputPageListDto : ApiResourceDtoBase
    {

        public string UserClaim { get; set; }

        /// <summary>
        /// Api秘钥
        /// </summary>
        public string ApiSecret { get; set; }

        /// <summary>
        /// 范围
        /// </summary>
        public string Scope { get; set; }
    }
}
