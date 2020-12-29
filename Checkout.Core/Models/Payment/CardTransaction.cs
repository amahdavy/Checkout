using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Core.Models.Payment
{
    /// <summary>
    /// Entity for Card transaction data.
    /// </summary>
    [Table("tbl_CardTransaction")]
    public class CardTransaction : TransactionBase
    {
        /// <summary>
        /// Card holder name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string HolderName { get; set; }

        /// <summary>
        /// Address of card holder
        /// </summary>
        [Required]
        [StringLength(200)]
        public string BillingAddress { get; set; }


        /// <summary>
        /// Card number
        /// </summary>
        [Required]
        [StringLength(19)]
        public string CardNumber { get; set; }

        /// <summary>
        /// CCV number
        /// </summary>
        [Required]
        [StringLength(4)]
        public string CCV { get; set; }

        /// <summary>
        /// Expire Year
        /// </summary>
        [Required]
        public int ExpYear { get; set; }

        /// <summary>
        /// Expire Month
        /// </summary>
        [Required]
        public int ExpMonth { get; set; }
    }
}
