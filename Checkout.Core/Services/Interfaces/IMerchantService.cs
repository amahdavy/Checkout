using Checkout.Core.DB;
using Checkout.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core.Services.Interfaces
{
    public interface IMerchantService
    {
        public Merchant GetMerchant(string emailAddress, string password);
        public MerchantProfile GetMerchantProfile(string apiKey);

        public MerchantProfile GetMerchantProfile(long id);

        public void AddMerchant(Merchant merchant);
    }
}
