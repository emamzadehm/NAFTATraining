#pragma checksum "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "818447d96959b862c0fdc2fa1d29dd4b097b983a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.CourseInstructor.Areas_AdminPanel_Pages_CourseManagement_CourseInstructor_RegisteredCandidates), @"mvc.1.0.view", @"/Areas/AdminPanel/Pages/CourseManagement/CourseInstructor/RegisteredCandidates.cshtml")]
namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.CourseInstructor
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"818447d96959b862c0fdc2fa1d29dd4b097b983a", @"/Areas/AdminPanel/Pages/CourseManagement/CourseInstructor/RegisteredCandidates.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"028b1354043967a0a4157598753b7c4c1fd854ff", @"/Areas/AdminPanel/Pages/_ViewImports.cshtml")]
    public class Areas_AdminPanel_Pages_CourseManagement_CourseInstructor_RegisteredCandidates : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor.CandidateCourseInstructorViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title"">لیست ثبت نام شدگان دوره </h4>
</div>

<div class=""modal-body"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th>نام فراگیر</th>
                <th>نام دوره</th>
                <th>نام استاد</th>
                <th>نام شرکت</th>
                <th>تاریخ ثبت نام</th>
                <th>تاریخ برگزاری</th>
                <th>تاریخ پایان</th>
</thead>
        <tbody>
");
#nullable restore
#line 23 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 26 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
               Write(item.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
               Write(item.CourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
               Write(item.InstructorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
               Write(item.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
               Write(item.RegistrationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
               Write(item.SDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
               Write(item.EDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Projects\NAFTA\Training\NT.Presentation.MVCCore\Areas\AdminPanel\Pages\CourseManagement\CourseInstructor\RegisteredCandidates.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor.CandidateCourseInstructorViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
