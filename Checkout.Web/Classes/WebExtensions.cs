
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Checkout.Web.Classes
{
    public static class WebExtensions
    {
        public static IEnumerable<SelectListItem> GetStaticStringSelectList(this IHtmlHelper htmlHelper, Type type)
        {
            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                string value = fieldInfo.GetValue(null).ToString();

                yield return new SelectListItem()
                {
                    Value = value,
                    Text = value
                };
            }
        }

        public static RedirectResult RedirectWithData(NameValueCollection data, string url)
        {
            StringBuilder postData = new StringBuilder();

            postData.Append("id=" + HttpUtility.UrlEncode("Mahdavi"));
            //postData.Append("last_name=" + HttpUtility.UrlEncode(txtLastName.Text));

            //ETC for all Form Elements

            // Now to Send Data.
            StreamWriter writer = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.ToString().Length;
            try
            {
                writer = new StreamWriter(request.GetRequestStream());
                writer.Write(postData.ToString());
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            
             return new RedirectResult(url, true);
            //Response.Redirect("NewPage");
        }

    }
}
