using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Core.Models.Common;
using Checkout.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Checkout.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPaymentService _IPaymentService;
        private readonly IMerchantService _IMerchantService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPaymentService IPaymentService, IMerchantService IMerchantService)
        {
            _logger = logger;
            _IPaymentService = IPaymentService;
            _IMerchantService = IMerchantService;
        }

        [HttpGet]
        public   IEnumerable<WeatherForecast> Get()
        {
            //_logger.LogInformation("Call Get Method ! LogInformation");
            //_logger.LogWarning("Call Get Method ! - LogWarning");

            

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
