#pragma checksum "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57ccebc3a62b44b79a12c4a7e235847eb76863af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ArticlesIT), @"mvc.1.0.view", @"/Views/Home/ArticlesIT.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\_ViewImports.cshtml"
using ASP.NET_Core_NewsApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\_ViewImports.cshtml"
using ASP.NET_Core_NewsApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57ccebc3a62b44b79a12c4a7e235847eb76863af", @"/Views/Home/ArticlesIT.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"158770cc9503ac43649002ea8954fdecba07da1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ArticlesIT : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASP.NET_Core_NewsApp.Models.Article>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<center><h3><i>Мир IT</i></h3></center>\r\n<br />\r\n<div class=\"row\">\r\n");
#nullable restore
#line 9 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg-4 col-md-6 mb-4\">\r\n            <div class=\"card\" style=\"width: 22rem;\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 329, "\"", 344, 1);
#nullable restore
#line 13 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
WriteAttributeValue("", 335, item.Img, 335, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 15 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 16 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
                                    Write(item.ShortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    ");
#nullable restore
#line 17 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
               Write(Html.ActionLink("Подробнее", "Details", new { id = item.Id }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"card-footer\">\r\n                    <small class=\"text-muted\">Дата добавления статьи:<br />");
#nullable restore
#line 20 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
                                                                      Write(item.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 24 "C:\Users\Admin\source\repos\ASP.NET_Core_NewsApp\ASP.NET_Core_NewsApp\Views\Home\ArticlesIT.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASP.NET_Core_NewsApp.Models.Article>> Html { get; private set; }
    }
}
#pragma warning restore 1591
