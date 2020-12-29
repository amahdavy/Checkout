using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Extensions.Validators
{
    public class DecimalPlacesValidateAttribute : ValidationAttribute
    {
        public int DecimalPlaces { get; }

        public DecimalPlacesValidateAttribute(int decimalPlaces)
        {
            DecimalPlaces = decimalPlaces;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            decimal amount = (decimal)value;
            string text = amount.ToString(CultureInfo.InvariantCulture);
            int dotIndex = text.IndexOf('.');
            var decimals = text.Length - dotIndex - 1;
            var places = DecimalPlaces switch
            {
                0 => "without decimal places",
                1 => "with one decimal place",
                _ => $"with {DecimalPlaces} decimal places"
            };
            return dotIndex < 0 || dotIndex != text.LastIndexOf('.') || decimals != DecimalPlaces
                ? new ValidationResult(ErrorMessage ?? $"Please enter an amount {places}")
                : ValidationResult.Success;
        }
    }
}
