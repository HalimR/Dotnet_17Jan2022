#pragma checksum "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "546f9931748fe54303c6b72b700d23e9ed037be9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
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
#line 1 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\_ViewImports.cshtml"
using SampleProductApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\_ViewImports.cshtml"
using SampleProductApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"546f9931748fe54303c6b72b700d23e9ed037be9", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aec66401ab2f6c9f556da376b42c5e88b49c9685", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SampleProductApplication.Models.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuyProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
  
    ViewData["Title"] = "Card List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Card List</h1>\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 10 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-md-4 col-xs-6 border-primary mb-3"">
            <div class=""card mb-3"" style=""max-width: 540px;"">
                <div class=""row g-0"">
                    <div class=""col-md-12"">
                        <div class=""card-header text-white bg-info"">
                            <p class=""card-text"">
                                <h5 class=""card-title"">
                                    ");
#nullable restore
#line 19 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </h5>\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 831, "\"", 847, 2);
            WriteAttributeValue("", 837, "/", 837, 1, true);
#nullable restore
#line 25 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
WriteAttributeValue("", 838, item.Pic, 838, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 848, "\"", 864, 1);
#nullable restore
#line 25 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
WriteAttributeValue("", 854, item.Name, 854, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" />\r\n                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <div class=\"card-body\"> \r\n                            <p class=\"card-text\"><b>Category: </b>");
#nullable restore
#line 29 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
                                                             Write(item.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"card-text\"><b>Price: </b>");
#nullable restore
#line 30 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
                                                          Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"card-text\"><b>Quanitity: </b>");
#nullable restore
#line 31 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
                                                              Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"card-text\"><b>Description: </b>");
#nullable restore
#line 32 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
                                                                Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-12\">\r\n                        <div class=\"card-footer \">\r\n                            <p class=\"card-text\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "546f9931748fe54303c6b72b700d23e9ed037be98368", async() => {
                WriteLiteral("\r\n                                    <i class=\"bi bi-eye-fill\"></i> Show Details\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
                                                                                             WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral(" \r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>");
#nullable restore
#line 46 "C:\Users\Abdul\Documents\Dotnet_17Jan2022\Day 18\repos\SampleProductSolution\SampleProductApplication\Views\Product\List.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SampleProductApplication.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
