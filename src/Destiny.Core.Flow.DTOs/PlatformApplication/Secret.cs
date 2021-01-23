using Destiny.Core.Flow.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.PlatformApplication
{
    public class Secret
    {
        public Secret()
        {
            Type = "SharedSecret";
        }
        public Secret(string value, DateTimeOffset? expiration) : this()
        {
            Value = value;
            Expiration = expiration;
        }
        public Secret(string description, string value, DateTimeOffset? expiration)
        {
            Description = description;
            Value = value;
            Expiration = expiration;
        }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTimeOffset? Expiration { get; set; }
        public string Type { get; set; }
        public override int GetHashCode()
        {
            return (17 * 23 + (Value?.GetHashCode() ?? 0)) * 23 + (Type?.GetHashCode() ?? 0);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Secret secret = obj as Secret;
            if (secret == null)
            {
                return false;
            }

            if (secret == this)
            {
                return true;
            }

            if (string.Equals(secret.Type, Type, StringComparison.Ordinal))
            {
                return string.Equals(secret.Value, Value, StringComparison.Ordinal);
            }

            return false;
        }
    }
}
