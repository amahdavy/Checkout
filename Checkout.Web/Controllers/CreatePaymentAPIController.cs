using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Core.Models.Payment;
using Checkout.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Checkout.Core.Utilities;
using Checkout.Core.Models.Common;
using Microsoft.Extensions.Configuration;

namespace Checkout.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreatePaymentAPIController : ControllerBase
    {
        private readonly ILogger<CreatePaymentAPIController> _logger;
        private readonly IPaymentService _IPaymentService;
        private readonly IMerchantService _IMerchantService;
        private readonly IConfiguration _configuration;

        public CreatePaymentAPIController(ILogger<CreatePaymentAPIController> logger, IPaymentService IPaymentService, IMerchantService IMerchantService, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _IPaymentService = IPaymentService;
            _IMerchantService = IMerchantService;
        }

         
      

       
        [HttpPost]
        public PaymentResponseMessage CreatePayment([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                var profileId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "ProfileId").Value);
                var merchantProfile = _IMerchantService.GetMerchantProfile(profileId);
                var temporaryTransaction = paymentRequest.ToTemporaryTransaction();
                temporaryTransaction.MerchantProfile = merchantProfile;
                temporaryTransaction.TestMode = merchantProfile.Mode == APIMode.Test;
                temporaryTransaction.TransctionCode = Guid.NewGuid().ToString();
                temporaryTransaction.PaymentStatus = "Open";

                return new PaymentResponseMessage()
                {
                    PaymentResponse = _IPaymentService.CreatePayment(temporaryTransaction),
                    ErrorCode = string.Empty,
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "CreatePaymentAsync");
                return new PaymentResponseMessage()
                {
                    PaymentResponse = null,
                    ErrorCode = "100",
                    ErrorMessage = "Error on saving data"
                };
            }

        }

         
    }
}
