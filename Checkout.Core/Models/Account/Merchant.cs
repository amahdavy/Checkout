
using Checkout.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Checkout.Core.Models.Account
{
    /// <summary>
    /// This entity save all data of a merchant in database
    /// </summary>
    [Table("tbl_Merchant")]
    public class Merchant : BaseEntity
    {
 
        public Merchant()  {

            this.Profiles = new List<MerchantProfile>();
        }

        
        /// <summary>
        /// Merchant name- Company name
        /// </summary>
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// The website of Merchant.
        /// </summary>
        [Required]
        [StringLength(250)]
        public string Website { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        
        /// <summary>
        /// Password. This password just use for login on the merchant's portal
        /// </summary>
        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        /// <summary>
        /// The latest time of activity on portal
        /// </summary>
        public DateTime? LastLoging { get; set; }

        /// <summary>
        /// A list of profiles. Evey Merchant can have many profile (Test or Live) for many shops
        /// </summary>
        public ICollection<MerchantProfile> Profiles { get; set; }
    }
}
