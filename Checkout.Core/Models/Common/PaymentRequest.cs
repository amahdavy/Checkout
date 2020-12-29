
using Checkout.Core.Models.Payment;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters; 

namespace Checkout.Core.Models.Common
{
    
    /// <summary>
    /// Merchant use this entity to send a payment creation request
    /// </summary>
    public class PaymentRequest 
    {

        /// <summary>
        /// The amount that you want to charge, e.g. {"currency":"EUR", "value":"100.00"} if you would want to charge €100.00.
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
        /// Allows you to preset the language to be used in the payment screens shown to the consumer. 
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Normally, a payment method selection screen is shown. However, when using this parameter, your customer will skip the 
        /// selection screen and will be sent directly to the chosen payment method. 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethods? Method { get; set; }

        /// <summary>
        /// Provide any data you like, for example a string or a JSON object. We will save the data alongside the payment. Whenever 
        /// you fetch the payment with our API, we’ll also include the metadata. You can use up to approximately 1kB.
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Indicate which type of payment this is in a recurring sequence. If set to first, a first payment is created for the 
        /// customer, allowing the customer to agree to automatic recurring charges taking place on their account in the future. 
        /// If set to recurring, the customer’s card is charged automatically. Defaults to oneoff, which is a regular non-recurring 
        /// payment(see also: Recurring).
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentSequenceType? SequenceType { get; set; }

        /// <summary>
        /// The ID of the Customer for whom the payment is being created. This is used for recurring payments and single click payments.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// When creating recurring payments, the ID of a specific Mandate may be supplied to indicate which of the consumer’s accounts 
        /// should be credited.
        /// </summary>
        public string MandateId { get; set; }
       

        
        public void SetMetadata(object metadataObj, JsonSerializerSettings jsonSerializerSettings = null)
        {
            this.Metadata = JsonConvert.SerializeObject(metadataObj, jsonSerializerSettings);
        }

        
    }
}
   

