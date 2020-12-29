using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Checkout.TestAPI.Extensions.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Checkout.TestAPI.Models
{
    public class PaymentModel : BaseModel
    {
        [Required]
        [Range(0.01, 1000, ErrorMessage = "Please enter an amount between 0.01 and 1000")]
        [DecimalPlacesValidate(2)]
        public decimal Amount { get; set; }

        [Required]
        [StringListValidate(typeof(Currency))]
        public string Currency { get; set; }

        [Required]
        public string Description { get; set; }

      
    }
}
