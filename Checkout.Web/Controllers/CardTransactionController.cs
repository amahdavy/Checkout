using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Core.Models.Common;
using Checkout.Core.Models.Payment;
using Checkout.Core.Services.Interfaces;
using Checkout.Core.Utilities;
using Checkout.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Checkout.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CardTransactionController : ControllerBase
    {
        private readonly ILogger<CardTransactionController> _logger;
        private readonly IPaymentService _IPaymentService;
       
        private readonly IConfiguration _configuration;

        public CardTransactionController(ILogger<CardTransactionController> logger, IPaymentService IPaymentService,   IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _IPaymentService = IPaymentService;
            
        }

        
        [HttpGet("Detail/{id}")]
        [Authorize]
        public CardTransactionInfoModel Detail(string id)
        {
            var cardTransaction = _IPaymentService.GetCardTransaction(id);
            return new CardTransactionInfoModel()
            {
                Amount = cardTransaction.Amount.Value,
                HolderName = cardTransaction.HolderName,
                CardNumber = cardTransaction.CardNumber,
                Currency = cardTransaction.Amount.Currency,
                Description = cardTransaction.TemporaryTransaction.Description,

            };
            
        }

        
        [HttpGet("GetPayments/{limit:int}")]
        [Authorize]
        public IEnumerable<PaymentResponse> GetPayments(int? limit)
        {
            var profileId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "ProfileId").Value);
            if (!limit.HasValue)
                limit = 20;

            if (limit > 20)
            {
                limit = 20;

            }
            var payments = _IPaymentService.GetPayments(profileId, limit.Value);
            List<PaymentResponse> paymentResponses = new List<PaymentResponse>();
            foreach (var item in payments)
            {

                var paymentResponse = item.ToPaymentResponse();
                paymentResponse.CheckoutUrl = Tools.GetCheckoutUrl(_configuration, item.TransctionCode);
                paymentResponses.Add(paymentResponse);
            }
            return paymentResponses;
        }
    }
}
