using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.Web.Models
{
    public class PaymentMethodModel
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Href { get; set; }
    }
}
