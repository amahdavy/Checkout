using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Models
{
    public class TransactionModel : BaseModel
    {
        public TransactionModel()
        {
            Transactions = new List<PaymentResponse> ();
        }       
        public List<PaymentResponse> Transactions { get; set; }
    }
}
