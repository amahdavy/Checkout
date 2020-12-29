using Checkout.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.Web.Models
{
    public class PaymentModel
    {
        public PaymentModel()
        {
            this.PaymentMethods = new List<PaymentMethodModel>();
        }
        public string Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }

        public string Merchant { get; set; }
        public string Logo { get; set; }
        public List<PaymentMethodModel> PaymentMethods { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public bool IsTestMode { get; set; }
    }
}
