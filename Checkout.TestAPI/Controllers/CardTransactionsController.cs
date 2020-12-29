using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Checkout.TestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Checkout.TestAPI.Controllers
{
    public class CardTransactionsController : Controller
    {
        private readonly ILogger<CardTransactionsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public CardTransactionsController(ILogger<CardTransactionsController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            TransactionModel model = new TransactionModel();
            return View(model);
        }


        public async Task<IActionResult> GetData(TransactionModel model)
        {
            TempData["APIKey"] = model.APIKey;
            List<PaymentResponse> paymentResponses = new List<PaymentResponse>();

            var token = "";
            using (var httpClient = new HttpClient())
            {
                var tokenRequest = new APIModeModel() { apiKey = model.APIKey };
                StringContent content = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{_configuration.GetSection("appSettings")["PaymentAPI"]}/Token", content))
                {
                    token = await response.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                using (var response = await httpClient.GetAsync($"{_configuration.GetSection("appSettings")["PaymentAPI"]}/CardTransaction/GetPayments/20"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    paymentResponses = JsonConvert.DeserializeObject<List<PaymentResponse>>(apiResponse);
                }
            }
            if (paymentResponses != null)
            {
                model.Transactions = paymentResponses;

            }

            return View("Index", model);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var APIKey =Convert.ToString( TempData["APIKey"]);
            var token = "";
            using (var httpClient = new HttpClient())
            {
                var tokenRequest = new APIModeModel() { apiKey = APIKey };
                StringContent content = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{_configuration.GetSection("appSettings")["PaymentAPI"]}/Token", content))
                {
                    token = await response.Content.ReadAsStringAsync();
                }
            }

            CardTransactionResponse cardTransactionResponse = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                using (var response = await httpClient.GetAsync($"{_configuration.GetSection("appSettings")["PaymentAPI"]}/CardTransaction/Detail/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cardTransactionResponse  = JsonConvert.DeserializeObject<CardTransactionResponse>(apiResponse);
                }
            }
             
            return View("detail", cardTransactionResponse);
        }
    }
}

