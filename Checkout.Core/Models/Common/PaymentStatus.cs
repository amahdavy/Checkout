using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Models.Common
{
    /// <summary>
    /// Paiment status. New transaction save in Open status
    /// </summary>
    public class PaymentStatus
    {
        public static string Paid = nameof(Paid);
        public static string Failed = nameof(Failed);
        public static string Canceled = nameof(Canceled);
        public static string Expired = nameof(Expired);
    }
}
