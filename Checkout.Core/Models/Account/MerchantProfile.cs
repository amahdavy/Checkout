using Checkout.Core.Models.Common;
using Checkout.Core.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Checkout.Core.Models.Account
{

    /// <summary>
    /// Profile for Merchant
    /// Profie means a connection between Merchant and our system
    /// Profile can configure on test mode or live mode
    /// </summary>
    [Table("tbl_MerchantProfile")]
    public class MerchantProfile : BaseEntity
    {
        public MerchantProfile()
        {
           
        }
        /// <summary>
        /// The profile's name should reflect the tradename or brand name of the profile's website or application.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL to the profile's website or application. The URL should start with http:// or https://.
        /// </summary>
        public string Website { get; set; }
         

        /// <summary>
        /// The URL to logo of profile.It will shows on payment screen on top
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// It shows, profile is on Test mode or live mode
        /// </summary>
        public APIMode Mode { get; set; }

        /// <summary>
        /// API key, use for authentication. Test API key starts with test_ and live start with live_
        /// </summary>
        public string APIKey { get; set; }

        /// <summary>
        /// relation to parent entity
        /// </summary>
        public Merchant Merchant { get; set; }

        public long MerchantId { get; set; }

        /// <summary>
        /// Profile can define which payment will accept. It will show on payment process and customer can select which method want to pay.
        /// e.g. paypal,credit card, applepay,..
        /// </summary>
        public ICollection<MerchantProfilesPaymentMethods> MerchantProfilesPaymentMethods { get; set; }
    }
}
