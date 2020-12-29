using Checkout.Core.Models.Account;
using Checkout.Core.Models.Common;
using Checkout.Core.Models.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Utilities
{
    static public class ExtentionsMethod
    {
        public static bool IsCaseInsensitiveEqual(this string value, string comparing)
        {
            return string.Compare(value, comparing, StringComparison.OrdinalIgnoreCase) == 0;
        }
        public static TemporaryTransaction ToTemporaryTransaction(this PaymentRequest value)
        {
            return new TemporaryTransaction()
            {
                Amount = value.Amount,
                CustomerId = value.CustomerId,
                Description = value.Description,
                Locale = value.Locale,
                MandateId = value.MandateId,
                Metadata = value.Metadata,
                RedirectUrl = value.RedirectUrl,
                SequenceType = value.SequenceType ?? PaymentSequenceType.FirstPayment,
                WebhookUrl = value.WebhookUrl 
            };

        }
        public static PaymentResponse ToPaymentResponse(this TemporaryTransaction value)
        {
            return new PaymentResponse()
            {
                Amount = value.Amount,
                CustomerId = value.CustomerId,
                Description = value.Description,
                Locale = value.Locale,
                MandateId = value.MandateId,
                Metadata = value.Metadata,
                RedirectUrl = value.RedirectUrl,
                WebhookUrl = value.WebhookUrl,
                PaymentSequenceType = value.SequenceType ?? PaymentSequenceType.FirstPayment,
                TransctionCode = value.TransctionCode,
                PaymentStatus = value.PaymentStatus,
                CreateDateTime = value.InsertDate
            };

        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>().HasData(new Merchant()
            {
                Id = 1,
                Email = "abolfazl.mahdavi@gmail.com",
                Name = "Mahdavy.com",
                Password = "123",
                Phone = "969696",
                Website = "http://www.mahdavy.com"
            }
            );

            modelBuilder.Entity<PaymentMethod>().HasData(
               new PaymentMethod() { Id = 1, Name = PaymentMethods.ApplePay.ToString(), Logo = "fab fa-apple-pay fa-lg" },
               new PaymentMethod() { Id = 2, Name = PaymentMethods.CreditCard.ToString(), Logo = "fa fa-credit-card fa-lg" },
               new PaymentMethod() { Id = 3, Name = PaymentMethods.DirectDebit.ToString(), Logo = "fa fa-credit-card fa-lg" },
               new PaymentMethod() { Id = 4, Name = PaymentMethods.BankTransfer.ToString(), Logo = "fa fa-university fa-lg" }

           );

            modelBuilder.Entity<MerchantProfile>(o =>
            o.HasData(
                new MerchantProfile()
                {
                    Id = 1,
                    APIKey = "test_a02f7e6a-7768-4244-8032-8979f25d9581",
                    Logo = "https://acropaq.com/image/data/logo.png",
                    Mode = APIMode.Test,
                    Name = "Mahdavi Shop 1",
                    Website = "shop.mahdavy.com" ,
                    MerchantId = 1
                },
            new MerchantProfile()
            {
                Id = 2,
                APIKey = "live_974281d1-0e8d-4279-a4fa-4e37cd002b74",
                Logo = "https://acropaq.com/image/data/logo.png",
                Mode = APIMode.Live,
                Name = "Mahdavi Shop",
                Website = "shop.mahdavy.com" ,
                MerchantId = 1 
            }));

            modelBuilder.Entity<MerchantProfilesPaymentMethods>().HasData(
                    new { Id = 1L, MerchantProfileId = 1L, PaymentMethodId = 1L, InsertDate = DateTime.Now },
                    new { Id = 2L, MerchantProfileId = 1L, PaymentMethodId = 2L, InsertDate = DateTime.Now },
                    new { Id = 3L, MerchantProfileId = 1L, PaymentMethodId = 4L, InsertDate = DateTime.Now });
        }
        public static string ToControllerName(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            string cName = name.Replace(" ", "");
            cName = cName.ToLower();
            cName = cName[0].ToString().ToUpper() + cName.Substring(1, cName.Length - 1);
            return cName;
        }


    }
}
