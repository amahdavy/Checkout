using Checkout.Core.Models.Payment;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Checkout.Core.Models.Common
{
    /// <summary>
    /// Return to merchant, with API
    /// </summary>
    public class PaymentResponse
    {
        /// <summary>
        /// The amount that you want to charge, e.g. {"currency":"EUR", "value":"100.00"}.
        /// </summary>
        public Amount Amount { get; set; }

        /// <summary>
        /// The description of the payment you’re creating. This will be shown to the consumer on their card or bank statement  
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Required - The URL the consumer will be redirected to after the payment process. It could make sense for the
        /// redirectURL to contain a unique
        /// identifier – like your order ID – so you can show the right page referencing the order when the consumer returns.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Set the webhook URL, where we will send payment status updates to.
        /// </summary>
        public string WebhookUrl { get; set; }


        /// <summary>
        /// Allows you to preset the language to be used in the payment screens shown to the consumer. Setting a locale is highly 
        /// recommended and will greatly improve your conversion rate. When this parameter is omitted, the browser language will 
        /// be used instead if supported by the payment method. You can provide any ISO 15897 locale, but our payment screen currently
        /// only supports the following languages: en_US and de_DE  
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Provide any data you like, for example a string or a JSON object. We will save the data alongside the payment. Whenever 
        /// you fetch the payment with our API, we’ll also include the metadata. You can use up to approximately 5000 Characters.
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Indicate which type of payment this is in a recurring sequence. If set to first, a first payment is created for the 
        /// customer, allowing the customer to agree to automatic recurring charges taking place on their account in the future. 
        /// If set to recurring, the customer’s card is charged automatically. Defaults to oneoff, which is a regular non-recurring 
        /// payment(see also: Recurring).
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentSequenceType? PaymentSequenceType { get; set; }

        /// <summary>
        /// The ID of the Customer for whom the payment is being created. This is used for recurring payments and single click payments.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// When creating recurring payments, the ID of a specific Mandate may be supplied to indicate which of the consumer’s accounts 
        /// should be credited.
        /// </summary>
        public string MandateId { get; set; }

        /// <summary>
        /// The URL for payment page 
        /// </summary>
        public  string CheckoutUrl { get; set; }

        /// <summary>
        /// A GUID code for transaction
        /// </summary>
        public string TransctionCode { get; set; }

        /// <summary>
        /// The status of payment.
        /// </summary>
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Create date and time
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}
