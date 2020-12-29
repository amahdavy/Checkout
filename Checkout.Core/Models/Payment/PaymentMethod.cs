using Checkout.Core.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Core.Models.Payment
{
    /// <summary>
    /// Payment methods
    /// It will show in payment page. You can define methods that profile can accept
    /// </summary>
    [Table("tbl_PaymentMethod")]
    public class PaymentMethod : BaseEntity
    {
        /// <summary>
        /// The name od payment method
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Logo for payment method. We use icons from https://fontawesome.com/
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Profile'S payment methods
        /// </summary>
        public ICollection<MerchantProfilesPaymentMethods> MerchantProfilesPaymentMethods { get; set; }
    }
}
