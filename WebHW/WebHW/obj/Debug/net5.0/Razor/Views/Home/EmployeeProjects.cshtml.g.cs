#pragma checksum "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c48c7e10b1357e63d120f02410bcdd8aefc983e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EmployeeProjects), @"mvc.1.0.view", @"/Views/Home/EmployeeProjects.cshtml")]
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
#line 1 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\_ViewImports.cshtml"
using WebHW;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\_ViewImports.cshtml"
using WebHW.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c48c7e10b1357e63d120f02410bcdd8aefc983e", @"/Views/Home/EmployeeProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b5468c40a632806aac534e3eede05b308114a1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EmployeeProjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
  
    ViewBag.Title = "Projects";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" of ");
#nullable restore
#line 7 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
                     Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
<table class=""table"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Customer</th>
            <th scope=""col"">Executor</th>
            <th scope=""col"">StartDate</th>
            <th scope=""col"">EndDate</th>
            <th scope=""col"">Priority</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 21 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
         foreach (Project projects in Model.Projects)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
           Write(projects.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
           Write(projects.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
           Write(projects.Customer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
           Write(projects.Executor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
           Write(projects.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 29 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
           Write(projects.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 30 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
           Write(projects.Priority);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Миша\source\repos\HW\WebHW\WebHW\Views\Home\EmployeeProjects.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
