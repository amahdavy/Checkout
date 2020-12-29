using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Checkout.Core.Models.Payment
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentSequenceType
    {
        [EnumMember(Value = "onetimepayment")] OneTimePayment,
        [EnumMember(Value = "firstpayment")] FirstPayment,
        [EnumMember(Value = "recurringpayment")] RecurringPayment
    }
    
}
