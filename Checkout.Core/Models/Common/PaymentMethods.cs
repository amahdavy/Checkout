using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Checkout.Core.Models.Common
{
    /// <summary>
    /// payment methods we accept
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethods
    {
         
        [EnumMember(Value = "banktransfer")] BankTransfer, 
        [EnumMember(Value = "bitcoin")] Bitcoin,
        [EnumMember(Value = "creditcard")] CreditCard,
        [EnumMember(Value = "directdebit")] DirectDebit, 
        [EnumMember(Value = "ideal")] Ideal, 
        [EnumMember(Value = "paypal")] PayPal, 
        [EnumMember(Value = "sofort")] Sofort,
        [EnumMember(Value = "refund")] Refund,
        [EnumMember(Value = "klarnapaylater")] KlarnaPayLater,
        [EnumMember(Value = "klarnasliceit")] KlarnaSliceIt, 
        [EnumMember(Value = "applepay")] ApplePay, 
    }
}
