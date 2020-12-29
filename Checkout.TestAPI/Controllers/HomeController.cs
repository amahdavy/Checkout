using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Checkout.TestAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace Checkout.TestAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            PaymentModel paymentModel = new PaymentModel()
            {
                Amount = 10,
                Currency = Currency.EUR,
                Description = "test for payment"
            };

            return View(paymentModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Index(PaymentModel paymentModel)
        {
            if (!this.ModelState.IsValid || paymentModel == null)
            {
                return this.View();
            }

            var token = "";
            using (var httpClient = new HttpClient())
            {
                var tokenRequest = new APIModeModel() { apiKey = paymentModel.APIKey };
                StringContent content = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{_configuration.GetSection("appSettings")["PaymentAPI"]}/Token", content))
                {
                    token = await response.Content.ReadAsStringAsync();
                }
            }

            var request = new PaymentRequest()
            {
                amount = new Amount() { currency = paymentModel.Currency, value = paymentModel.Amount.ToString() },
                description = paymentModel.Description,
                locale = "DE",
                redirectUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/home/Success",
                sequenceType = 1,
                webhookUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/home/Success",
                method = 1
            };

            PaymentResponseMessage paymentResponseMessage = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{_configuration.GetSection("appSettings")["PaymentAPI"]}/CreatePaymentAPI", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paymentResponseMessage = JsonConvert.DeserializeObject<PaymentResponseMessage>(apiResponse);
                }
            }
            if (paymentResponseMessage != null)
            {
                if (paymentResponseMessage.ErrorCode == string.Empty)
                    return this.Redirect(paymentResponseMessage.PaymentResponse.CheckoutUrl);
                else
                {
                    _logger.LogError(paymentResponseMessage.ErrorMessage);
                    // Show Error 
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
            return View();
        }


        [HttpPost]
        [Route("home/Success")]
        public IActionResult Success()
        {
            SuccessModel model = new SuccessModel();
            model.TransctionCode = Request.Form["id"];
            model.PaymentStatus = Request.Form["PaymentStatus"];
            return View(model);
        }



    }
}
