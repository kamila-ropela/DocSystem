#pragma checksum "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\DoctorView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90237cf9a505843b00f4d4faa09cdeb12396b829"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_DoctorView), @"mvc.1.0.view", @"/Views/Doctor/DoctorView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Doctor/DoctorView.cshtml", typeof(AspNetCore.Views_Doctor_DoctorView))]
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
#line 1 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\_ViewImports.cshtml"
using DocSystem;

#line default
#line hidden
#line 2 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\_ViewImports.cshtml"
using DocSystem.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90237cf9a505843b00f4d4faa09cdeb12396b829", @"/Views/Doctor/DoctorView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1038db87bcb6d8d25694842ab14cd66bf45fc969", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_DoctorView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Patients", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\DoctorView.cshtml"
  
    ViewData["Title"] = "DoctorView";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(95, 16, true);
            WriteLiteral("\r\n<br>\r\n<br>\r\n\r\n");
            EndContext();
            BeginContext(111, 224, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05db26bd59514930a732748219264ff0", async() => {
                BeginContext(162, 166, true);
                WriteLiteral("\r\n    <p>\r\n        Type PESEL or surname: <input type=\"text\" name=\"SearchString\">\r\n        <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n\r\n    </p>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(335, 60, true);
            WriteLiteral("\r\n<br>\r\n<button class=\"btn btn-primary\">Add visit</button>\r\n");
            EndContext();
            BeginContext(396, 45, false);
#line 19 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\DoctorView.cshtml"
Write(Html.Partial("PatientInfo", ViewData["data"]));

#line default
#line hidden
            EndContext();
            BeginContext(441, 21, true);
            WriteLiteral("\r\n\r\n<h1>Visits</h1>\r\n");
            EndContext();
            BeginContext(463, 49, false);
#line 22 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\DoctorView.cshtml"
Write(Html.Partial("PatientVisits", ViewData["visits"]));

#line default
#line hidden
            EndContext();
            BeginContext(512, 19, true);
            WriteLiteral("\r\n\r\n<h1>Docs</h1>\r\n");
            EndContext();
            BeginContext(532, 44, false);
#line 25 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\DoctorView.cshtml"
Write(Html.Partial("PatientDoc", ViewData["docs"]));

#line default
#line hidden
            EndContext();
            BeginContext(576, 20, true);
            WriteLiteral("\r\n\r\n<h1>Tests</h1>\r\n");
            EndContext();
            BeginContext(597, 47, false);
#line 28 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\DoctorView.cshtml"
Write(Html.Partial("PatientTests", ViewData["tests"]));

#line default
#line hidden
            EndContext();
            BeginContext(644, 27, true);
            WriteLiteral("\r\n\r\n<h1>Prescription</h1>\r\n");
            EndContext();
            BeginContext(672, 58, false);
#line 31 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\DoctorView.cshtml"
Write(Html.Partial("PatientPrescription", ViewData["prescript"]));

#line default
#line hidden
            EndContext();
            BeginContext(730, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
