using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Checkout.Core.Models.Common;
using Checkout.Core.Models.Payment;

namespace Checkout.Core.Services.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// Create a payment request.
        /// </summary>
        /// <param name="temporaryTransaction">request value</param>
        /// <returns></returns>
        PaymentResponse CreatePayment(TemporaryTransaction temporaryTransaction);

        /// <summary>
        /// Load a temporary transaction with transaction code
        /// </summary>
        /// <param name="transactionCode"></param>
        /// <returns></returns>
        TemporaryTransaction GetTemporaryTransaction(string transactionCode);

        /// <summary>
        ///		Retrieve a single payment object by its payment identifier.
        /// </summary>
        /// <param name="paymentId">The payment's ID, for example tr_7UhSN1zuXS.</param>
        /// <param name="testmode">Oauth - Optional – Set this to true to get a payment made in test mode. If you omit this parameter, you can only retrieve live mode payments.</param>
        /// <returns></returns>
        Task<PaymentResponse> GetPaymentAsync(string paymentId, bool testmode = false);

        /// <summary>
        /// Some payment methods are cancellable for an amount of time, usually until the next day. Or as long as the payment status is open. Payments may be cancelled manually from the Dashboard, or automatically by using this endpoint.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
	    Task DeletePaymentAsync(string paymentId);

        /// <summary>
        /// Retrieve all payments created with the current payment profile, ordered from newest to oldest.
        /// </summary>
        /// <param name="profileId"></param> 
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<TemporaryTransaction> GetPayments(long profileId, int limit = 20);

        /// <summary>
        /// Insert a new credit card transaction
        /// </summary>
        /// <param name="cardTransaction"></param>
        void AddTransaction(CardTransaction cardTransaction);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStatus"></param>
        void UpdateTemporaryTransactionPaymentStatus(long id, string newStatus);

        /// <summary>
        /// Get a card transaction with transaction code
        /// </summary>
        /// <param name="transactionCode"></param>
        /// <returns></returns>
        CardTransaction GetCardTransaction(string transactionCode);
    }
}
