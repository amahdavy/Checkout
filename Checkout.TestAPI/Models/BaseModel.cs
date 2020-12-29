using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.TestAPI.Models
{
    public class BaseModel
    {
        public string APIKey { get; set; }

        public IEnumerable<SelectListItem> GetAPIKeys()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem("Test Mode API", "test_a02f7e6a-7768-4244-8032-8979f25d9581",true));
            selectListItems.Add(new SelectListItem("Live Mode API", "live_974281d1-0e8d-4279-a4fa-4e37cd002b74"));

            return selectListItems;
        }
    }
}
