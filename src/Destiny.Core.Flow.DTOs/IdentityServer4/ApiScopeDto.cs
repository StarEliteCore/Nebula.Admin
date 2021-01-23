using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
    public class ApiScopeDto : IDto<Guid>
    {
        public Guid Id { get; set; }


        //
        // 摘要:
        //     Indicates if this resource is enabled. Defaults to true.
        public bool Enabled
        {
            get;
            set;
        } = true;


        //
        // 摘要:
        //     The unique name of the resource.
        public string Name
        {
            get;
            set;
        }

        //
        // 摘要:
        //     Display name of the resource.
        public string DisplayName
        {
            get;
            set;
        }

        //
        // 摘要:
        //     Description of the resource.
        public string Description
        {
            get;
            set;
        }

        //
        // 摘要:
        //     Specifies whether this scope is shown in the discovery document. Defaults to
        //     true.
        public bool ShowInDiscoveryDocument
        {
            get;
            set;
        } = true;


        //
        // 摘要:
        //     List of associated user claims that should be included when this resource is
        //     requested.
        public ICollection<string> UserClaims
        {
            get;
            set;
        } = new HashSet<string>();


        //
        // 摘要:
        //     Gets or sets the custom properties for the resource.
        //
        // 值:
        //     The properties.
        public IDictionary<string, string> Properties
        {
            get;
            set;
        } = new Dictionary<string, string>();

        /// <summary>
        /// 是否必须
        /// </summary>
        [Description("是否必须")]
        public bool Required { get; set; }

        /// <summary>
        /// 是否强调显示
        /// </summary>
        [Description("是否强调显示")]
        public bool Emphasize { get; set; }
    }
}
