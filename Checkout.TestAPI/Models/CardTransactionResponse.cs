using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Models
{
    public class CardTransactionResponse
    {
        public string Amount { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }


        public string HolderName { get; set; }

        public string CardNumber { get; set; }
    }
}
