#pragma checksum "C:\Users\pasindu\source\repos\RaysCourses\RaysCoursesApplication\Views\Shared\_UserDropDown.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2349fac0e64cc78c867f24362d2da8ec40e10e82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UserDropDown), @"mvc.1.0.view", @"/Views/Shared/_UserDropDown.cshtml")]
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
#line 1 "C:\Users\pasindu\source\repos\RaysCourses\RaysCoursesApplication\Views\_ViewImports.cshtml"
using RaysCoursesApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pasindu\source\repos\RaysCourses\RaysCoursesApplication\Views\_ViewImports.cshtml"
using RaysCoursesApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\pasindu\source\repos\RaysCourses\RaysCoursesApplication\Views\Shared\_UserDropDown.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2349fac0e64cc78c867f24362d2da8ec40e10e82", @"/Views/Shared/_UserDropDown.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4d9efbf8add96903ec5d31fdd23bc0c91f6991", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UserDropDown : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<li class=""nav-item dropdown no-arrow"">
    <a class=""nav-link dropdown-toggle"" href=""#"" id=""userDropdown"" role=""button""
       data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
        <span class=""mr-2 d-none d-lg-inline text-gray-600 small"">");
#nullable restore
#line 8 "C:\Users\pasindu\source\repos\RaysCourses\RaysCoursesApplication\Views\Shared\_UserDropDown.cshtml"
                                                             Write(HttpContextAccessor.HttpContext.Session.GetString("UserName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
        <img class=""img-profile rounded-circle""
             src=""img/undraw_profile.svg"">
    </a>
    <!-- Dropdown - User Information -->
    <div class=""dropdown-menu dropdown-menu-right shadow animated--grow-in""
         aria-labelledby=""userDropdown"">
        <a class=""dropdown-item""");
            BeginWriteAttribute("href", " href=\"", 720, "\"", 758, 1);
#nullable restore
#line 15 "C:\Users\pasindu\source\repos\RaysCourses\RaysCoursesApplication\Views\Shared\_UserDropDown.cshtml"
WriteAttributeValue("", 727, Url.Action("LoginView","User"), 727, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-sign-in fa-sm fa-fw mr-2 text-gray-400\"></i>\r\n            Sign In\r\n        </a>\r\n        <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 903, "\"", 944, 1);
#nullable restore
#line 19 "C:\Users\pasindu\source\repos\RaysCourses\RaysCoursesApplication\Views\Shared\_UserDropDown.cshtml"
WriteAttributeValue("", 910, Url.Action("RegisterView","User"), 910, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            <i class=""fa fa-user-plus fa-sm fa-fw mr-2 text-gray-400""></i>
            Sign Up
        </a>
        <div class=""dropdown-divider""></div>
        <a class=""dropdown-item"" data-toggle=""modal"" data-target=""#logoutModal"">
            <i class=""fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400""></i>
            Logout
        </a>
    </div>
</li>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
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
