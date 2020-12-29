using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Models
{
    public class CardPaymentModel
    {
        public string Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }

        public string Merchant { get; set; }
        public string Logo { get; set; }
       
        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string ExpMonth { get; set; }

        public string ExpYear { get; set; }

        public string CCV { get; set; }

        public string BillingAddress { get; set; }
    }
}
