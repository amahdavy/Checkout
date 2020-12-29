using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Core.Models.Common;
using Checkout.Core.Services.Interfaces;
using Checkout.Core.Utilities;
using Checkout.Web.Classes;
using Checkout.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCore.Mvc.Extensions.RedirectAndPost;

namespace Checkout.Web.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }


        [Route("Payment/Payment-Method/{id?}")]
        public IActionResult Payment(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return View();

            var tr = _paymentService.GetTemporaryTransaction(id);
            if (tr == null)
            {
                _logger.LogError($"Can not find payment request by Id = {id}");
                Response.StatusCode = 404;
                return View("NotFound");
            }
            PaymentModel model = new PaymentModel();
            foreach (var item in tr.MerchantProfile.MerchantProfilesPaymentMethods)
            {
                var cName = item.PaymentMethod.Name.ToControllerName();
                if (!cName.ToLower().Equals(PaymentMethods.CreditCard.ToString().ToLower()))
                    cName = "/Home/NotImplementedException"; // Becuase other payment method does not implemented
                else cName = $"/Payment/{cName}/{id}";

                model.PaymentMethods.Add(new PaymentMethodModel() { Image = item.PaymentMethod.Logo, Name = item.PaymentMethod.Name, Href = $"{cName}" });

            }

            model.Id = id;
            model.Amount = tr.Amount.Value;
            model.Currency = tr.Amount.Currency;
            model.Logo = tr.MerchantProfile.Logo;
            model.Description = tr.Description;
            model.Merchant = tr.MerchantProfile.Name;
            model.IsTestMode = tr.MerchantProfile.Mode == APIMode.Test ;

            return View(model);
        }

        [Route("Payment/CreditCard/{id?}")]
        public IActionResult CreditCard(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return View();

            var temporaryTransaction = _paymentService.GetTemporaryTransaction(id);
            
            if (temporaryTransaction == null)
            {
                _logger.LogError($"Can not find payment request by Id = {id}");
                Response.StatusCode = 404;
                return View("NotFound");
            }

            CardPaymentModel model = new CardPaymentModel();
            model.Id = id;
            model.Amount = temporaryTransaction.Amount.Value;
            model.Currency = temporaryTransaction.Amount.Currency;
            model.Logo = temporaryTransaction.MerchantProfile.Logo; //"/merchantlogos/acropaqlogo.png";
            model.Description = temporaryTransaction.Description;
            model.Merchant = temporaryTransaction.MerchantProfile.Name;
            model.IsTestMode = temporaryTransaction.MerchantProfile.Mode == APIMode.Test;
           
            return View(model);
        }

        [HttpPost]
        [Route("Payment/CreditCard/PayWithCard")]
        public IActionResult PayWithCard(CardPaymentModel model)
        {
            var temporaryTransaction = _paymentService.GetTemporaryTransaction(model.Id);

            if (temporaryTransaction == null)
            {
                _logger.LogError($"Can not find payment request by Id = {model.Id}");
                Response.StatusCode = 404;
                return View("NotFound");
            }

             //in live mode we get payment status from bank and set

            if (model.PaymentStatus == PaymentStatus.Paid)
            {
                Core.Models.Payment.CardTransaction cardTransaction = new Core.Models.Payment.CardTransaction()
                {
                    Amount = temporaryTransaction.Amount,
                    CardNumber = model.CardNumber,
                    CCV = model.CCV,
                    ExpMonth = Convert.ToInt32(model.ExpMonth),
                    ExpYear = Convert.ToInt32(model.ExpYear),
                    InsertDate = DateTime.Now,
                    TransactionDate = DateTime.Now,
                    TransctionCode = temporaryTransaction.TransctionCode,
                    //PaymentStatus = model.PaymentStatus,
                    MerchantProfile = temporaryTransaction.MerchantProfile,
                    BillingAddress = model.BillingAddress,
                    HolderName = model.CardName,
                    TemporaryTransaction = temporaryTransaction
                };

                _paymentService.AddTransaction(cardTransaction);
            }
            else
            {
                _paymentService.UpdateTemporaryTransactionPaymentStatus(temporaryTransaction.Id, model.PaymentStatus);
            }

            Dictionary<string, object> objData = new Dictionary<string, object>();
            objData.Add("Id", temporaryTransaction.TransctionCode);
            objData.Add("PaymentStatus", model.PaymentStatus);


            return this.RedirectAndPost(temporaryTransaction.RedirectUrl, objData);
        }
    }
}
