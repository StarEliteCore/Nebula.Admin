using DestinyCore.Extensions;
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


        private string _value;
        public string Value
        {
            get => _value;
            set => _value = value.Sha256();
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
        } = "SharedSecret";



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
