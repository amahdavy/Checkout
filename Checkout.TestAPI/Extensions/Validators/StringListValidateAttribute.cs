using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Extensions.Validators
{
    public class StringListValidateAttribute : ValidationAttribute
    {
        private readonly Type _staticClass;

        public StringListValidateAttribute(Type staticClass)
        {
            this._staticClass = staticClass;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<string> validValues = this._staticClass
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => x.GetValue(null).ToString());

            if (validValues.Contains(value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The value \"{value}\" is invalid");
        }
    }
}