#pragma checksum "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "517fcdeaa3626dd35b75cdbb49b4e0a28350d580"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_bookservice_getFavPros), @"mvc.1.0.view", @"/Views/bookservice/getFavPros.cshtml")]
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
#line 1 "F:\Halperland\Helperland\Sample\Views\_ViewImports.cshtml"
using Sample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Halperland\Helperland\Sample\Views\_ViewImports.cshtml"
using Sample.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"517fcdeaa3626dd35b75cdbb49b4e0a28350d580", @"/Views/bookservice/getFavPros.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57e79f35ab23d95c3437adaa71cb286883eafee9", @"/Views/_ViewImports.cshtml")]
    public class Views_bookservice_getFavPros : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FavoriteAndBlocked>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
 foreach (var FandB in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"fav-pro-card\">\r\n        <input type=\"radio\" name=\"radioForFav\"");
            BeginWriteAttribute("id", " id=\"", 145, "\"", 169, 1);
#nullable restore
#line 5 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
WriteAttributeValue("", 150, FandB.TargetUserId, 150, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 170, "\"", 197, 1);
#nullable restore
#line 5 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
WriteAttributeValue("", 178, FandB.TargetUserId, 178, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 215, "\"", 257, 1);
#nullable restore
#line 7 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
WriteAttributeValue("", 221, FandB.TargetUser.UserProfilePicture, 221, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 258, "\"", 264, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"fav-pro-img\">\r\n        <p>");
#nullable restore
#line 8 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
      Write(FandB.TargetUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 8 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
                                   Write(FandB.TargetUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <label");
            BeginWriteAttribute("for", " for=\"", 374, "\"", 399, 1);
#nullable restore
#line 9 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
WriteAttributeValue("", 380, FandB.TargetUserId, 380, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"radioLabel\">Select</label>\r\n    </div>\r\n");
#nullable restore
#line 11 "F:\Halperland\Helperland\Sample\Views\bookservice\getFavPros.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FavoriteAndBlocked>> Html { get; private set; }
    }
}
#pragma warning restore 1591
