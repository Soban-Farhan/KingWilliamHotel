#pragma checksum "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfbc5f8a8c3fb47fab74bb5b34c69a95892d197c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TblPersons_Details), @"mvc.1.0.view", @"/Views/TblPersons/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TblPersons/Details.cshtml", typeof(AspNetCore.Views_TblPersons_Details))]
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
#line 1 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\_ViewImports.cshtml"
using KingWilliamHotelManagementAPI;

#line default
#line hidden
#line 2 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\_ViewImports.cshtml"
using KingWilliamHotelManagementAPI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfbc5f8a8c3fb47fab74bb5b34c69a95892d197c", @"/Views/TblPersons/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f87d3c73012df5c59ab0a95617ae7a8cbf1c1c", @"/Views/_ViewImports.cshtml")]
    public class Views_TblPersons_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KingWilliamHotelManagementAPI.Models.TblPerson>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(100, 132, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>TblPerson</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(233, 45, false);
#line 14 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(278, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(342, 41, false);
#line 17 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(383, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(446, 44, false);
#line 20 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(490, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(554, 40, false);
#line 23 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(594, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(657, 48, false);
#line 26 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StreetNumber));

#line default
#line hidden
            EndContext();
            BeginContext(705, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(769, 44, false);
#line 29 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.StreetNumber));

#line default
#line hidden
            EndContext();
            BeginContext(813, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(876, 46, false);
#line 32 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StreetName));

#line default
#line hidden
            EndContext();
            BeginContext(922, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(986, 42, false);
#line 35 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.StreetName));

#line default
#line hidden
            EndContext();
            BeginContext(1028, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1091, 40, false);
#line 38 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1131, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1195, 36, false);
#line 41 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1231, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1294, 46, false);
#line 44 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1340, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1404, 42, false);
#line 47 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1446, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1509, 43, false);
#line 50 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1552, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1616, 39, false);
#line 53 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1655, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1718, 47, false);
#line 56 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1765, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1829, 43, false);
#line 59 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1872, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1935, 48, false);
#line 62 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EmailAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1983, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2047, 44, false);
#line 65 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
       Write(Html.DisplayFor(model => model.EmailAddress));

#line default
#line hidden
            EndContext();
            BeginContext(2091, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2138, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfbc5f8a8c3fb47fab74bb5b34c69a95892d197c13384", async() => {
                BeginContext(2190, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 70 "C:\Users\soban\source\repos\FinalProject_KingWilliamHotelManagementAPI\FinalProject_KingWilliamHotelManagementAPI\Views\TblPersons\Details.cshtml"
                           WriteLiteral(Model.PersonId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2198, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2206, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfbc5f8a8c3fb47fab74bb5b34c69a95892d197c15778", async() => {
                BeginContext(2228, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2244, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KingWilliamHotelManagementAPI.Models.TblPerson> Html { get; private set; }
    }
}
#pragma warning restore 1591
