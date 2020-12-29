using Checkout.Core.Models.Account;
using Checkout.Core.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Core.Models.Payment
{
    [Table("tbl_MerchantProfilesPaymentMethods")]
    public class MerchantProfilesPaymentMethods : BaseEntity
    {
        public  PaymentMethod PaymentMethod { get; set; }
        public MerchantProfile MerchantProfile { get; set; }
    }
}
