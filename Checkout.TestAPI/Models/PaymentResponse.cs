using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Models
{
    public class PaymentResponse
    {  
        public Amount Amount { get; set; }
        public string Description { get; set; }
        public string RedirectUrl { get; set; }
        public string WebhookUrl { get; set; }
        public string Locale { get; set; }
        public string Metadata { get; set; }
        public int PaymentSequenceType { get; set; }
        public string CustomerId { get; set; }
        public string MandateId { get; set; }
        public string CheckoutUrl { get; set; }

        public string TransctionCode { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
    public class PaymentResponseMessage
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public PaymentResponse PaymentResponse { get; set; }
    }
}
