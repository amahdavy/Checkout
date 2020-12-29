using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Utilities
{
    public class Tools
    {
        public static string GetCheckoutUrl(IConfiguration configuration, string transactionCode)
        {
            return $"{configuration.GetSection("appSettings")["CheckoutURL"]}/{transactionCode}";
        }
    }
}
