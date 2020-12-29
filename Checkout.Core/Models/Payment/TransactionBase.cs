using Checkout.Core.Models.Account;
using Checkout.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Core.Models.Payment
{
    /// <summary>
    /// A base class for all transaction types
    /// </summary>
    [Table("tbl_TransactionBase")]
    public class TransactionBase : BaseEntity
    {
         
        [Required]
        [StringLength(50)]
        public string TransctionCode { get; set; }

        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Profile that used for creation a payment request
        /// </summary>
        public MerchantProfile MerchantProfile { get; set; }
 
        /// <summary>
        /// amout with currency
        /// </summary>
        public Amount Amount { get; set; }

        /// <summary>
        /// Relation to Temporary request, which request paid
        /// </summary>
        public TemporaryTransaction TemporaryTransaction { get; set; }
    }
}
