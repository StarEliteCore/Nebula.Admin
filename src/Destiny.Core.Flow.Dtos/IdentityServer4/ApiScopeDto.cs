using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
    public class ApiScopeDto :InputDto<Guid>
    {
  


      
        public bool Enabled
        {
            get;
            set;
        } = false;


     
        public string Name
        {
            get;
            set;
        }

     
        public string DisplayName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }


        public bool ShowInDiscoveryDocument
        {
            get;
            set;
        } = true;


        public ICollection<string> UserClaims
        {
            get;
            set;
        } = new HashSet<string>();


        public IDictionary<string, string> Properties
        {
            get;
            set;
        } = new Dictionary<string, string>();

     
        [Description("是否必须")]
        public bool Required { get; set; } = false;

        /// <summary>
        /// 是否强调显示
        /// </summary>
        [Description("是否强调显示")]
        public bool Emphasize { get; set; } = false;
    }
}
