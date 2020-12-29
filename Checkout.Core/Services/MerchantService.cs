using Checkout.Core.DB;
using Checkout.Core.Models.Account;
using Checkout.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Checkout.Core.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public MerchantService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
        }
        public void AddMerchant(Merchant merchant)
        {
            using (var contex = new CheckoutDBContext(_connectionString))
            {
                contex.Merchant.Add(merchant);
                contex.SaveChanges();
            }
        }

        public Merchant GetMerchant(string emailAddress, string password)
        {
            using (var contex = new CheckoutDBContext(_connectionString))
            {
               return contex.Merchant.FirstOrDefaultAsync(m=>m.Email.ToLower().Equals(emailAddress.ToLower()) && m.Password.Equals(password)).GetAwaiter().GetResult();               
            }
        }

        public MerchantProfile GetMerchantProfile(string apiKey)
        {
            using (var contex = new CheckoutDBContext(_connectionString))
            {
                return contex.MerchantProfile
                    .Include(o => o.Merchant)
                    .FirstOrDefaultAsync(m => m.APIKey.Equals(apiKey))
                    .GetAwaiter()
                    .GetResult();
            }
        }

        public MerchantProfile GetMerchantProfile(long id)
        {
            using (var contex = new CheckoutDBContext(_connectionString))
            {
                return contex.MerchantProfile
                    .Include(o => o.Merchant)
                    .FirstOrDefaultAsync(m => m.Id.Equals(id))
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
