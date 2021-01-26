using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
   public class ApiResourceSecretDto
    {

        public string Description
        {
            get;
            set;
        }


        public string Value
        {
            get;
            set;
        }


        public DateTime? Expiration
        {
            get;
            set;
        }


        public string Type
        {
            get;
            set;
        }


        public ApiResourceSecretDto()
        {
            Type = "SharedSecret";
           
        }


        public ApiResourceSecretDto(string value) : this()
        {
            Value = value.Sha256();

        }

        //public ApiResourceSecretDto(string value, DateTime? expiration = null)
        //    : this()
        //{
        //    Value = value;
        //    Expiration = expiration;
        //}



        //public ApiResourceSecretDto(string value, string description, DateTime? expiration = null)
        //    : this()
        //{
        //    Description = description;
        //    Value = value;
        //    Expiration = expiration;
        //}
    }
}
