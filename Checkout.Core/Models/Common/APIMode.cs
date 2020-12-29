using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Checkout.Core.Models.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum APIMode
    {
        [EnumMember(Value = "live")] Live,
        [EnumMember(Value = "test")] Test
    }

}
