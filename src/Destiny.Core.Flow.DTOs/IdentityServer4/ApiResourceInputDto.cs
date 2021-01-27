using System;
using System.Collections.Generic;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
   
    /// <summary>
    /// API资源输入DTO
    /// </summary>

    public class ApiResourceInputDto: ApiResourceDtoBase, IInputDto<Guid>
    {
        public string ApiSecretValue { get; set; }

        public string ScopeVaule { get; set; }
        public ICollection<string> AllowedAccessTokenSigningAlgorithms
        {
            get;
            set;
        } = new HashSet<string>();

    }
}