#pragma checksum "C:\Users\ASUS\Documents\GitHub\OvertimeRequest\OvertimeRequest\OvertimeRequestMVC\Views\Dashboard\Department.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85910aef83118f92657e8ae5d5f1095838eb18aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Department), @"mvc.1.0.view", @"/Views/Dashboard/Department.cshtml")]
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
#line 1 "C:\Users\ASUS\Documents\GitHub\OvertimeRequest\OvertimeRequest\OvertimeRequestMVC\Views\_ViewImports.cshtml"
using OvertimeRequestMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Documents\GitHub\OvertimeRequest\OvertimeRequest\OvertimeRequestMVC\Views\_ViewImports.cshtml"
using OvertimeRequestMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85910aef83118f92657e8ae5d5f1095838eb18aa", @"/Views/Dashboard/Department.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1214c2936227095f969a330cb4fedbda812d7a50", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Department : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ASUS\Documents\GitHub\OvertimeRequest\OvertimeRequest\OvertimeRequestMVC\Views\Dashboard\Department.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome Department Data</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
    <div class=""content-header"">
        <div class=""container-fluid"">
            <div class=""container-fluid"">
                <table class=""display table table-bordered text-dark mydatatable"" id=""tableDepartment"">
                    <thead>
                        <tr>
                            <th scope=""col"" class=""text"">No</th>
                            <th scope=""col"" class=""text"">Name</th>
");
            WriteLiteral("                        </tr>\r\n                    </thead>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" />
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.10.24/js/jquery.dataTables.js""></script>
    <script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.7.0/js/dataTables.buttons.min.js""></script>

    <script>
        debugger;
        $(document).ready(function () {
            $('#tableDepartment').DataTable({
                ""ajax"": {
                    url: ""https://localhost:44323/api/Department"",
                    //url: ""/Request/GetHistoryRequest"",
                    type: ""GET"",
                    dataType: ""json"",
                    dataSrc: """"
                },
                ""columns"": [
                    //{ ""data"": ""id"" },
                    {
             ");
                WriteLiteral(@"           ""data"": null,
                        ""render"": function (data, type, row, meta) { return meta.row + meta.settings._iDisplayStart + 1; }
                    },
                    //{ ""data"": ""id"" },
                    { ""data"": ""Name"" }

                ]
            });
        });
    </script>
");
            }
            );
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
