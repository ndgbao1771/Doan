#pragma checksum "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\Manage\DisplayRecoveryCodes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce215f0739b7b80acda2d198ac4d1dbf7e577265"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Views_Manage_DisplayRecoveryCodes), @"mvc.1.0.view", @"/Areas/Identity/Views/Manage/DisplayRecoveryCodes.cshtml")]
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
#line 1 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\_ViewImports.cshtml"
using App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\_ViewImports.cshtml"
using App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.RoleViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.UserViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce215f0739b7b80acda2d198ac4d1dbf7e577265", @"/Areas/Identity/Views/Manage/DisplayRecoveryCodes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"870eac7ef56e7dc3e77e5dc5c5abc2fbdd4c53ab", @"/Areas/Identity/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Identity_Views_Manage_DisplayRecoveryCodes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DisplayRecoveryCodesViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\Manage\DisplayRecoveryCodes.cshtml"
  
    ViewData["Title"] = "Mã phục hồi";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>");
#nullable restore
#line 6 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\Manage\DisplayRecoveryCodes.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h1>\n<p class=\"text-success\">");
#nullable restore
#line 7 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\Manage\DisplayRecoveryCodes.cshtml"
                   Write(ViewData["StatusMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n\n<div>\n    <h4>Đây là các mã phục hồi của bạn</h4>\n    <p>Lưu trữ các mã này đề phòng khi đăng nhập cần xác thực hai yếu tố</p>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>Codes:</dt>\n");
#nullable restore
#line 15 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\Manage\DisplayRecoveryCodes.cshtml"
         foreach (var code in Model.Codes)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dd>\n            <text>");
#nullable restore
#line 18 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\Manage\DisplayRecoveryCodes.cshtml"
             Write(code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</text>\n        </dd>\n");
#nullable restore
#line 20 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Identity\Views\Manage\DisplayRecoveryCodes.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DisplayRecoveryCodesViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
