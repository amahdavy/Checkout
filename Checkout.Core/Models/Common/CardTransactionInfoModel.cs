using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Models.Common
{
    /// <summary>
    /// Model for return card information on API level
    /// </summary>
    public class CardTransactionInfoModel
    {
        /// <summary>
        /// value of transaction
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Curreny
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Description of transaction. it will set with merchant payment request.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Card holder name
        /// </summary>
        public string HolderName { get; set; }

        /// <summary>
        /// card number. we show just 4 digit of first and 4 last digit
        /// </summary>
        public string CardNumber { get; set; }

         
    }
}
