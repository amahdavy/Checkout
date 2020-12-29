using Checkout.Core.Models.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Models.Common
{
    /// <summary>
    /// Response for payment request.
    /// </summary>
    public class PaymentResponseMessage
    {
        /// <summary>
        /// Error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Response of payment request creation
        /// </summary>
        public PaymentResponse PaymentResponse { get; set; }
    }
}
