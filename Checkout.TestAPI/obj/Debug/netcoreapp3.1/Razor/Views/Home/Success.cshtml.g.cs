#pragma checksum "E:\SourceCodes\CheckoutSln\Checkout.TestAPI\Views\Home\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6de33749c0d63a6236b3a593fbd4027e001f5fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Success), @"mvc.1.0.view", @"/Views/Home/Success.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\SourceCodes\CheckoutSln\Checkout.TestAPI\Views\_ViewImports.cshtml"
using Checkout.TestAPI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\SourceCodes\CheckoutSln\Checkout.TestAPI\Views\_ViewImports.cshtml"
using Checkout.TestAPI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\SourceCodes\CheckoutSln\Checkout.TestAPI\Views\_ViewImports.cshtml"
using Checkout.TestAPI.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6de33749c0d63a6236b3a593fbd4027e001f5fa", @"/Views/Home/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9571375182f83479aee82a92a73d3ffc03239fc1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SuccessModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\SourceCodes\CheckoutSln\Checkout.TestAPI\Views\Home\Success.cshtml"
  
    ViewData["Title"] = "Success";

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n<div class=\"text-center\">\r\n    <h3 class=\"display-4\">  Payment done with</h3>\r\n</div>\r\n\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col\">Transaction Code :</div>\r\n        <div class=\"col\">");
#nullable restore
#line 14 "E:\SourceCodes\CheckoutSln\Checkout.TestAPI\Views\Home\Success.cshtml"
                    Write(Model.TransctionCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col\">Payment Status :</div>\r\n        <div class=\"col\">");
#nullable restore
#line 18 "E:\SourceCodes\CheckoutSln\Checkout.TestAPI\Views\Home\Success.cshtml"
                    Write(Model.PaymentStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SuccessModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
