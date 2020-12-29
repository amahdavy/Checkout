using Checkout.Core.Models.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.Web.Models
{
    public class CardPaymentModel
    {
        public string Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }

        public string Merchant { get; set; }
        public string Logo { get; set; }
       
        public string PaymentStatus { get; set; }

        public bool IsTestMode { get; set; }

        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public  string ExpMonth { get; set; }

        public string ExpYear { get; set; }

        public string CCV { get; set; }

        public string BillingAddress { get; set; }

        public IEnumerable<SelectListItem> GetExpirYears()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = new List<SelectListItem>();
            for (int i = 0; i < 10; i++)
            {
                var year = DateTime.Now.AddYears(i).Year;

                selectListItems.Add(new SelectListItem(string.Format("{0:D4}", year), string.Format("{0:D4}",year)  ,i == 0));
            }
            

            return selectListItems;
        }
    }
}
