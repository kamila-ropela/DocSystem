#pragma checksum "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adebea8857fddc2f3a00fa9cd68d87ea46c52aed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_PatientTests), @"mvc.1.0.view", @"/Views/Doctor/PatientTests.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Doctor/PatientTests.cshtml", typeof(AspNetCore.Views_Doctor_PatientTests))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adebea8857fddc2f3a00fa9cd68d87ea46c52aed", @"/Views/Doctor/PatientTests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1038db87bcb6d8d25694842ab14cd66bf45fc969", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_PatientTests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DocSystem.Models.Test>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 86, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(130, 38, false);
#line 7 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(168, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(224, 45, false);
#line 10 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayNameFor(model => model.PatientId));

#line default
#line hidden
            EndContext();
            BeginContext(269, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(325, 44, false);
#line 13 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayNameFor(model => model.DoctorId));

#line default
#line hidden
            EndContext();
            BeginContext(369, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(425, 40, false);
#line 16 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(465, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(521, 41, false);
#line 19 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayNameFor(model => model.Value));

#line default
#line hidden
            EndContext();
            BeginContext(562, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(618, 47, false);
#line 22 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(665, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(721, 40, false);
#line 25 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(761, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 31 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(879, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(928, 37, false);
#line 34 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(965, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1021, 44, false);
#line 37 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayFor(modelItem => item.PatientId));

#line default
#line hidden
            EndContext();
            BeginContext(1065, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1121, 43, false);
#line 40 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayFor(modelItem => item.DoctorId));

#line default
#line hidden
            EndContext();
            BeginContext(1164, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1220, 39, false);
#line 43 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1259, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1315, 40, false);
#line 46 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayFor(modelItem => item.Value));

#line default
#line hidden
            EndContext();
            BeginContext(1355, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1411, 46, false);
#line 49 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1457, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1513, 39, false);
#line 52 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1552, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 55 "C:\Users\pance\Desktop\DocSystem\DocSystem\Views\Doctor\PatientTests.cshtml"
}

#line default
#line hidden
            BeginContext(1591, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DocSystem.Models.Test>> Html { get; private set; }
    }
}
#pragma warning restore 1591
