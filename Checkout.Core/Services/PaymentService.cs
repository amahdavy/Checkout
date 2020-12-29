using Checkout.Core.DB;
using Checkout.Core.Models.Common;
using Checkout.Core.Models.Payment;
using Checkout.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Checkout.Core.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Checkout.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
        }
        public void AddTransaction(CardTransaction cardTransaction)
        {
            using (var contex = new CheckoutDBContext(_connectionString))
            {
                var temporaryTransaction = cardTransaction.TemporaryTransaction;
                temporaryTransaction.PaymentStatus = PaymentStatus.Paid;
                temporaryTransaction.ModifyDate = DateTime.Now;
                contex.Entry(temporaryTransaction).State = EntityState.Modified;
                contex.TemporaryTransaction.Update(temporaryTransaction);

                contex.CardTransaction.Attach(cardTransaction);
                contex.Entry(cardTransaction).State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public PaymentResponse CreatePayment(TemporaryTransaction temporaryTransaction)
        {
            using (var contex = new CheckoutDBContext(_connectionString))
            {
                contex.TemporaryTransaction.Attach(temporaryTransaction);
                contex.Entry(temporaryTransaction).State = EntityState.Added;
                contex.SaveChanges();
            }

            PaymentResponse paymentResponse = temporaryTransaction.ToPaymentResponse();
            paymentResponse.CheckoutUrl = Tools.GetCheckoutUrl(_configuration, temporaryTransaction.TransctionCode);

            return paymentResponse;


        }

        public Task DeletePaymentAsync(string paymentId)
        {
            throw new NotImplementedException();
        }

        public List<TemporaryTransaction> GetPayments(long profileId, int limit = 20)
        {
            using (var context = new CheckoutDBContext(_connectionString))
            {

                var transactions = context.TemporaryTransaction
                    .Include(o => o.MerchantProfile)
                    .ThenInclude(o => o.MerchantProfilesPaymentMethods)
                    .ThenInclude(o => o.PaymentMethod)                   
                    .Where(t => t.MerchantProfile.Id == profileId)
                    .OrderByDescending(t => t.InsertDate);


                return transactions.Take(limit).ToList();

            }
        }

        public Task<PaymentResponse> GetPaymentAsync(string paymentId, bool testmode = false)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Load a temporary transaction with transaction code
        /// </summary>
        /// <param name="transactionCode"></param>
        /// <returns></returns>
        public TemporaryTransaction GetTemporaryTransaction(string transactionCode)
        {

            using (var context = new CheckoutDBContext(_connectionString))
            {
                // contex.Configuration.LazyLoadingEnabled = true;
                var tr = context.TemporaryTransaction
                    .Include(o => o.MerchantProfile)
                    .ThenInclude(o => o.MerchantProfilesPaymentMethods)
                    .ThenInclude(o => o.PaymentMethod)
                    .FirstOrDefault(o => o.TransctionCode == transactionCode);

                return tr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStatus"></param>
       public void UpdateTemporaryTransactionPaymentStatus(long id, string newStatus)
        {
            using (var contex = new CheckoutDBContext(_connectionString))
            {
                var temporaryTransaction = contex.TemporaryTransaction.Find(id);
                temporaryTransaction.PaymentStatus = newStatus;
                temporaryTransaction.ModifyDate = DateTime.Now;
                contex.Entry(temporaryTransaction).State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
        /// <summary>
        /// Get a card transaction with transaction code
        /// </summary>
        /// <param name="transactionCode"></param>
        /// <returns></returns>
        public CardTransaction GetCardTransaction(string transactionCode)
        {
            using (var context = new CheckoutDBContext(_connectionString))
            {
                 
                var tr = context.CardTransaction
                    .Include(o => o.TemporaryTransaction) 
                    .FirstOrDefault(o => o.TransctionCode == transactionCode);

                return tr;
            }
        }
    }
}
