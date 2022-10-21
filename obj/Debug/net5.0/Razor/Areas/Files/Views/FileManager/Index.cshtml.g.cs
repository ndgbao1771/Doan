#pragma checksum "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\FileManager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f4a054a6aaa604c508342e020aedba98fcfe3c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Files_Views_FileManager_Index), @"mvc.1.0.view", @"/Areas/Files/Views/FileManager/Index.cshtml")]
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
#line 1 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\_ViewImports.cshtml"
using App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\_ViewImports.cshtml"
using App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.RoleViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\_ViewImports.cshtml"
using App.Areas.Identity.Models.UserViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f4a054a6aaa604c508342e020aedba98fcfe3c5", @"/Areas/Files/Views/FileManager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"870eac7ef56e7dc3e77e5dc5c5abc2fbdd4c53ab", @"/Areas/Files/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Files_Views_FileManager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div id=""elfinder"" class=""h-100"">

</div>


<script type=""text/javascript"">
    // Documentation for client options:
    // https://github.com/Studio-42/elFinder/wiki/Client-configuration-options
    $(document).ready(function () {
        var myCommands = elFinder.prototype._options.commands;

        // Not yet implemented commands in elFinder.NetCore
        var disabled = ['callback', 'chmod', 'editor', 'netmount', 'ping', 'search', 'zipdl', 'help'];
        elFinder.prototype.i18.en.messages.TextArea = ""Edit"";

        $.each(disabled, function (i, cmd) {
            (idx = $.inArray(cmd, myCommands)) !== -1 && myCommands.splice(idx, 1);
        });

        var options = {
            baseUrl: """);
#nullable restore
#line 23 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\FileManager\Index.cshtml"
                 Write(Url.Content("~/lib/elfinder/"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            url: \"");
#nullable restore
#line 24 "D:\Developer\Code\Projects\NetCore\AppMVC.Net\Areas\Files\Views\FileManager\Index.cshtml"
             Write(Url.Action("Connector"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            rememberLastDir: false,
            commands: myCommands,
            height: ""100%"",
            lang: 'vi',
            uiOptions: {
                toolbar: [
                    ['back', 'forward'],
                    ['reload'],
                    ['home', 'up'],
                    ['mkdir', 'mkfile', 'upload'],
                    ['open', 'download'],
                    ['undo', 'redo'],
                    ['info'],
                    ['quicklook'],
                    ['copy', 'cut', 'paste'],
                    ['rm'],
                    ['duplicate', 'rename', 'edit'],
                    ['selectall', 'selectnone', 'selectinvert'],
                    ['view', 'sort']
                ]
            },
            //onlyMimes: [""image"", ""text/plain""] // Get files of requested mime types only
            lang: 'vi',
        };
        $('#elfinder').elfinder(options).elfinder('instance');
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
