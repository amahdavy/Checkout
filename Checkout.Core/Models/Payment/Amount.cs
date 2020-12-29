﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace Checkout.Core.Models.Payment
{
    [ComplexType]
    public class Amount
    {
        /// <summary>
        /// An ISO 4217 currency code. The currencies supported depend on the payment methods that are enabled on your account.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// An ISO 4217 currency code. The currencies supported depend on the payment methods that are enabled on your account.
        /// </summary>
        public string Value { get; set; }

        public Amount(string currency, string value)
        {
            this.Currency = currency;
            this.Value = value;
        }

        /// <summary>
        /// Constructor for constructing based on a decimal value
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="value"></param>
        public Amount(string currency, decimal value)
        {
            this.Currency = currency;
            this.Value = value.ToString("0.00", CultureInfo.InvariantCulture);
        }

        public Amount() { }

        /// <summary>
        /// Implicit cast operator from Amount to decimal.
        /// </summary>
        /// <param name="amount"></param>
        public static implicit operator decimal(Amount amount)
            => Decimal.TryParse(amount.Value, NumberStyles.Number, CultureInfo.InvariantCulture, out var @decimal) ? @decimal : 
            throw new InvalidCastException($"Cannot convert {amount.Value} to decimal");

        public override string ToString()
        {
            return $"{this.Value} {this.Currency}";
        }
    }
}
