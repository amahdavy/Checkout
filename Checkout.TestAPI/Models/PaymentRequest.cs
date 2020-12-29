using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Models
{
    
    public class Amount
    {
        public string currency { get; set; }
        public string value { get; set; }

        public override string ToString()
        {
            return value + " " + currency;
        }
    }

    public class PaymentRequest
    {
        public Amount amount { get; set; }
        public string description { get; set; }
        public string redirectUrl { get; set; }
        public string webhookUrl { get; set; }
        public string locale { get; set; }
        public int method { get; set; }
        public string metadata { get; set; }
        public int sequenceType { get; set; }
        public string customerId { get; set; }
        public string mandateId { get; set; }
    }

}
