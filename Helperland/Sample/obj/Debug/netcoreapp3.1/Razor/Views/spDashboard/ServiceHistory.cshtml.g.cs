#pragma checksum "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "311aae9f92fef27058deb714a78d111215c8ef4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_spDashboard_ServiceHistory), @"mvc.1.0.view", @"/Views/spDashboard/ServiceHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"311aae9f92fef27058deb714a78d111215c8ef4f", @"/Views/spDashboard/ServiceHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57e79f35ab23d95c3437adaa71cb286883eafee9", @"/Views/_ViewImports.cshtml")]
    public class Views_spDashboard_ServiceHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sample.Models.ServiceRequest>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/excelExport.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/sort.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-table"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/calendar2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/layer-14.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/layer-15.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "15", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "20", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "311aae9f92fef27058deb714a78d111215c8ef4f6904", async() => {
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
            WriteLiteral(@"

    <div class=""ToastBack"" id=""displayServiceHistoryC"">
        <div class=""ToastContainer"" id=""containerService"">
            <div class=""toast-header"">
                <h3>Service Details</h3>
                <a onclick=""closeServiceHistory()"">x</a>
            </div>
            <p id=""dateTimeDisplayC"">07/03/2022 02:00 PM - 05:00 PM</p>
            <hr>
            <p>Service ID : <label id=""serviceIdDisplayC"">3</label></p>

            <hr>
            <p>Customer Name : <label id=""customerNameDisplayC"">xyz</label></p>
            <p>Service Address : <label id=""serviceAddressDisplayC"">xyz</label></p>
            <hr>
        </div>
    </div>

<table id=""TableExcel"" style=""display:none;"">
    <tr>
        <th>Service ID</th>
        <th>Service Date</th>
        <th>Customer Details</th>
    </tr>
");
#nullable restore
#line 27 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
     foreach (var items in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 30 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
           Write(items.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 31 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
              
                var date = items.ServiceStartDate;
                var time = date.ToString("hh:mm tt");
                var d = date.ToString("dd/MM/yyyy");
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        <td> ");
#nullable restore
#line 36 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
        Write(d);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 36 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
             Write(time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td colspan=\"2\">");
#nullable restore
#line 37 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                   Write(items.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                         Write(items.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br> ");
#nullable restore
#line 37 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                   Write(items.ServiceRequestaddress.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                             Write(items.ServiceRequestaddress.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 37 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                       Write(items.ServiceRequestaddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                                         Write(items.ServiceRequestaddress.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 39 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</table>

<table class=""table"" id=""Table"">
    <tr class=""no-border"">
        <td colspan=""6"">
            <div class=""heading-table"">
                <h3>Service History</h3>
                <button class=""submit-button"" onclick=""exportTableToExcel('TableExcel','Service History')"">Export Table Data To Excel File</button>
            </div>
        </td>
    </tr>
    <tr>
        <th onclick=""sortTable(0,2,2)"">Service ID ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f12747", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n        <th onclick=\"sortTable(1,2,2)\">Service Date ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f13921", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n        <th colspan=\"2\" onclick=\"sortTable(2,2,2)\">Customer details ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f15113", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n    </tr>\r\n");
#nullable restore
#line 56 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
     foreach (var items in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td");
            BeginWriteAttribute("onclick", " onclick=\"", 2274, "\"", 2337, 3);
            WriteAttributeValue("", 2284, "openModelForServiceHistory(\'", 2284, 28, true);
#nullable restore
#line 59 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
WriteAttributeValue("", 2312, items.ServiceRequestId, 2312, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2335, "\')", 2335, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 59 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                   Write(items.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 60 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
      
        var date = items.ServiceStartDate;
        var time = date.ToString("hh:mm tt");
        var d = date.ToString("dd/MM/yyyy");
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <td");
            BeginWriteAttribute("onclick", " onclick=\"", 2528, "\"", 2591, 3);
            WriteAttributeValue("", 2538, "openModelForServiceHistory(\'", 2538, 28, true);
#nullable restore
#line 65 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
WriteAttributeValue("", 2566, items.ServiceRequestId, 2566, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2589, "\')", 2589, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f18185", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 65 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                        Write(d);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f19618", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 65 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                                    Write(time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td colspan=\"2\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2737, "\"", 2800, 3);
            WriteAttributeValue("", 2747, "openModelForServiceHistory(\'", 2747, 28, true);
#nullable restore
#line 66 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
WriteAttributeValue("", 2775, items.ServiceRequestId, 2775, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2798, "\')", 2798, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 66 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                               Write(items.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 66 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                     Write(items.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f22283", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 66 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                Write(items.ServiceRequestaddress.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 66 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                                                          Write(items.ServiceRequestaddress.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 66 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                                                                                                    Write(items.ServiceRequestaddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 66 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                                                                                                                                      Write(items.ServiceRequestaddress.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n</tr>\r\n");
#nullable restore
#line 68 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        
        <tr>
            <td colspan=""6"">
                <div class=""footer-table"">
                    <div class=""left-side"">
                        <h3>Show </h3>
                        <select id=""select"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "311aae9f92fef27058deb714a78d111215c8ef4f25600", async() => {
                WriteLiteral("5");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "311aae9f92fef27058deb714a78d111215c8ef4f26783", async() => {
                WriteLiteral("10");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "311aae9f92fef27058deb714a78d111215c8ef4f27967", async() => {
                WriteLiteral("15");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "311aae9f92fef27058deb714a78d111215c8ef4f29151", async() => {
                WriteLiteral("20");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </select>\r\n                        <h3>entries : ");
#nullable restore
#line 81 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                 Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                    </div>
                    <div class=""right-side"">
                        <div id=""pageNavPosition"" class=""pager-nav""></div>

                        <script>
                            let pag = new Pager('Table', 5);

                            pag.init();
                            pag.showPageNav('pag', 'pageNavPosition');
                            pag.showPage(1);
                        </script>
                    </div>
                </div>
            </td>
        </tr>
    </table>
<table class=""card"">
    <tr class=""no-border"">
        <td colspan=""6"">
            <div class=""heading-table"">
                <h3>Service History</h3>
            </div>
        </td>
    </tr>
");
#nullable restore
#line 107 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
     foreach (var items in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <div class=\"card-table-tr\">\r\n                    <h4>");
#nullable restore
#line 112 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                   Write(items.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <hr>\r\n");
#nullable restore
#line 114 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                      
                        var date = items.ServiceStartDate;
                        var time = date.ToString("hh:mm tt");
                        var d = date.ToString("dd/MM/yyyy");
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f32445", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 119 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                       Write(d);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f33825", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 119 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                              Write(time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <hr>\r\n                    <p>");
#nullable restore
#line 121 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                  Write(items.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 121 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                        Write(items.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "311aae9f92fef27058deb714a78d111215c8ef4f35814", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 121 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                   Write(items.ServiceRequestaddress.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 121 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                             Write(items.ServiceRequestaddress.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 121 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                                       Write(items.ServiceRequestaddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 121 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
                                                                                                                                                                                                                         Write(items.ServiceRequestaddress.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 125 "F:\Halperland\Helperland\Sample\Views\spDashboard\ServiceHistory.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </table>");
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
