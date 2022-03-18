#pragma checksum "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21428f9f9ddba9f261ed0f7b86755666081c657a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_adminDashboard_IndexPartial), @"mvc.1.0.view", @"/Views/adminDashboard/IndexPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21428f9f9ddba9f261ed0f7b86755666081c657a", @"/Views/adminDashboard/IndexPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57e79f35ab23d95c3437adaa71cb286883eafee9", @"/Views/_ViewImports.cshtml")]
    public class Views_adminDashboard_IndexPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sample.Models.ServiceRequest>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/layer-15.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
 foreach (var items in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 5 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
       Write(items.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 6 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
          
            var date = items.ServiceStartDate;
            var time = date.ToString("hh:mm tt");
            DateTime endDate = date.AddHours(items.ServiceHours);
            var extra = items.ExtraHours ?? 0.0;
            endDate = endDate.AddHours(extra);
            var EndTime = endDate.ToString("hh:mm tt");
            var d = date.ToString("dd/MM/yyyy");
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <td><img class=\"img-table\" src=\"images/calendar2.png\"> ");
#nullable restore
#line 15 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                                          Write(d);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br> <img class=\"img-table\" src=\"images/layer-14.png\"> ");
#nullable restore
#line 15 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                                                                                                    Write(time);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 15 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                                                                                                            Write(EndTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 17 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
       Write(items.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                             Write(items.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "21428f9f9ddba9f261ed0f7b86755666081c657a6040", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
             if (items.ServiceRequestaddress != null)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 21 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                 Write(items.ServiceRequestaddress.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 21 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                                           Write(items.ServiceRequestaddress.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 21 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                                                                                       Write(items.ServiceRequestaddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 21 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                                                                                                                         Write(items.ServiceRequestaddress.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 22 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 26 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
             if (items.ServiceProviderId == null)
            {

            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
           Write(items.ServiceProvider.FirstName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                            Write(items.ServiceProvider.LastName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
                                                                                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>");
#nullable restore
#line 35 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
       Write(items.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 36 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
       Write(items.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n");
#nullable restore
#line 38 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
             if (items.Status == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"status new\" id=\"status\">New</span>\r\n");
#nullable restore
#line 41 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
             if (items.Status == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"status new\" id=\"status\">Cancelled</span>\r\n");
#nullable restore
#line 45 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
             if (items.Status == 3)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"status new\" id=\"status\">Completed</span>\r\n");
#nullable restore
#line 49 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
             if (items.Status == 4)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"status new\" id=\"status\">Accepted</span>\r\n");
#nullable restore
#line 53 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td class=\"action\">\r\n");
#nullable restore
#line 56 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
             if (items.Status == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <i class=""fas fa-ellipsis-v btn-option"" id=""button""></i>
                <br>
                <div class=""action-options"" id=""dialoug"">
                    <ul>
                        <li>Edit & Reschedule</li>
                        <li>Refund</li>
                        <li>Cancel</li>
                        <li>Change SP</li>
                        <li>Escalate</li>
                        <li>History Log</li>
                        <li>Download Invoice</li>
                    </ul>
                </div>
");
#nullable restore
#line 71 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n    </tr>\r\n");
#nullable restore
#line 74 "F:\Halperland\Helperland\Sample\Views\adminDashboard\IndexPartial.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sample.Models.ServiceRequest>> Html { get; private set; }
    }
}
#pragma warning restore 1591
