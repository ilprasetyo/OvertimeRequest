#pragma checksum "C:\Users\ASUS\Documents\GitHub\OvertimeRequest\OvertimeRequest\OvertimeRequestMVC\Views\Home\Manager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "815cbe0b9af5282a91c40fe6333e44f1f16615d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Manager), @"mvc.1.0.view", @"/Views/Home/Manager.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"815cbe0b9af5282a91c40fe6333e44f1f16615d8", @"/Views/Home/Manager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1214c2936227095f969a330cb4fedbda812d7a50", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Manager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formrole"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ASUS\Documents\GitHub\OvertimeRequest\OvertimeRequest\OvertimeRequestMVC\Views\Home\Manager.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "LayoutManager";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome Home Manager</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>

    <div class=""content"">
        <!-- Content Header (Page header) -->
        <div class=""content-header"">
            <div class=""container-fluid"">
                <div class=""container-fluid"">
                    <table class=""display table table-bordered text-dark mydatatable"" id=""tableact"">
                        <thead>
                            <tr>
                                <th scope=""col"" class=""text"">No</th>
                                <th scope=""col"">Id</th>
                                <th scope=""col"" class=""text"">NIK</th>
                                <th scope=""col"" class=""text"">Name</th>
                                <th scope=""col"" class=""text"">Manager NIK</th>
                                <th scope=""col"" class=""text"">Start</th>
                                <");
            WriteLiteral(@"th scope=""col"" class=""text"">End</th>
                                <th scope=""col"" class=""text"">Reason</th>
                                <th scope=""col"" class=""text"">Payroll</th>
                                <th scope=""col"" class=""text"">Action</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""Request"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""addModalLabel"">Approve Request</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "815cbe0b9af5282a91c40fe6333e44f1f16615d86094", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-6"">
                            <div class=""form-group"">
                                <label for=""id"" class=""col-form-label"">Id:</label>
                                <input disabled type=""text"" class=""form-control"" id=""id"" name=""id"">
                            </div>
                            <div class=""form-group"">
                                <label for=""id"" class=""col-form-label"">NIK:</label>
                                <input disabled type=""text"" class=""form-control"" id=""nik"" name=""nik"">
                            </div>
                            <div class=""form-group"">
                                <label for=""id"" class=""col-form-label"">Name:</label>
                                <input disabled type=""text"" class=""form-control"" id=""name"" name=""name"">
                            </div>
                        </div>
                        <div class=""col-6"">
                           ");
                WriteLiteral(@" <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Start Hours:</label>
                                <input disabled type=""text"" class=""form-control"" id=""starthours"" name=""startshours"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">End Hours:</label>
                                <input disabled type=""text"" class=""form-control"" id=""endhours"" name=""endhours"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Reason:</label>
                                <input disabled id=""reason"" class=""form-control"" name=""reason"">
                            </div>
                            <div class=""form-group"">
                                <label for=""id"" class=""col-form-label"">Payroll:</label>
                                ");
                WriteLiteral("<input disabled type=\"text\" class=\"form-control\" id=\"payroll\" name=\"payroll\">\r\n                            </div>\r\n                        </div>\r\n                        \r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" onclick=""approve()"">Approve</button>
                <button type=""button"" class=""btn btn-primary"" onclick=""reject()"">Reject</button>
            </div>
        </div>
    </div>
</div>
");
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
            $('#tableact').DataTable({
                ""ajax"": {
                    url: 'https://localhost:44323/api/Request/GetApproveManager3',
                    type: ""GET"",
                    dataType: ""json"",
                    dataSrc: """"
                },
                ""columnDefs"": [{
                    targets: [-1, -2, -3],
                    orderable: false
                }],
                ""co");
                WriteLiteral(@"lumns"": [
                    //{ ""data"": ""id"" },
                    {
                        ""data"": null,
                        ""render"": function (data, type, row, meta) { return meta.row + meta.settings._iDisplayStart + 1; }
                    },
                    { ""data"": ""Id"" },
                    { ""data"": ""NIK"" },
                    { ""data"": ""Name"" },
                    { ""data"": ""ManagerId"" },
                    {
                        render: function (data, type, row) {
                            var date = moment(row['StartHours']).format('DD MMMM YYYY, h:mm:ss a');
                            return date;
                        }
                    },
                    {
                        render: function (data, type, row) {
                            var date = moment(row['EndHours']).format('DD MMMM YYYY, h:mm:ss a');
                            return date;
                        }
                    },
                    { ""data"": ""Reason"" }");
                WriteLiteral(@",
                    { ""data"": ""Payroll"" },
                    {
                        'data': null,
                        ""render"": function (data, type, row, meta) {
                            return `<button class=""btn btn-primary"" type=""button"" id=""showdata""><a><i class=""fa fa-eye"" aria-hidden=""true""></i></a></button>`;
                        }
                    }                    
                ]
            });
        });

        function approve() {
            var id = $('#Id').val();
            console.log(""put accessed"");
            Approve(id);
        }

        function reject() {
            var id = $('#Id').val();
            console.log(""put accessed"");
            Reject(id);
        }
        
        $(""#tableact"").on('click', '#showdata', function () {
            var data = $(""#tableact"").DataTable().row($(this).parents('tr')).data();
            console.log(data);
            $(""#Request"").modal(""show"");
            $(""#nik"").val(data.NIK);");
                WriteLiteral(@"
            $(""#name"").val(data.Name);
            $(""#starthours"").val(moment(data.StartHours).format('DD MMMM YYYY, h:mm:ss a'));
            $(""#endhours"").val(moment(data.EndHours).format('DD MMMM YYYY, h:mm:ss a'));
            $(""#reason"").val(data.Reason);
            $(""#payroll"").val(data.Payroll);
            $(""#id"").val(data.Id);
        });


        function Get(Id) {
            console.log(Id);
            $.ajax({
                url: ""/Approve/Get"",
                data: { Id: Id }
            }).done((result) => {
                console.log(result);
                var obj = JSON.parse(result);
                $(""#Request"").modal(""show"");
                $(""#nik"").val(data.NIK);
                $(""#name"").val(data.Name);
                $(""#starthours"").val(data.StartHours);
                $(""#endhours"").val(data.EndHours);
                $(""#reason"").val(data.Reason);
                $(""#payroll"").val(data.Payroll);
                $(""#id"").val(data.Id);
      ");
                WriteLiteral(@"      }).fail((error) => {
                console.log(error);
            })
        }

        function Approve(Id) {
            var approve = new Object();
            approve.RequestId = $('#id').val();
            approve.NIK = $('#nik').val();
            $.ajax({
                type: ""POST"",
                url: '/ApproveManager/Approve',
                data: approve
            }).done((result) => {
                console.log(""ok"");
                if (result == 200) {
                    swal('Success', 'Update Successfully', 'success').then(() => {
                        location.reload(true)
                    });
                    $('#Request').modal('hide');
                    $(""#nik"").val(null);
                    $(""#name"").val(null);
                    $(""#starthours"").val(null);
                    $(""#endhours"").val(null);
                    $(""#reason"").val(null);
                    $(""#payroll"").val(null);
                    $(""#id"").val(null);
   ");
                WriteLiteral(@"                 /*$(""#statusrequest"").val(null);*/
                    //$(""#ApprovedHRD"").val(null);
                    //$(""#ApprovedManager"").val(null);
                    table.ajax.reload();
                }
                else {
                    swal('Error', 'Something Went Wrong', 'error').then(() => {
                        location.reload(true)
                    });
                }
            }).fail((error) => {
                console.log(error)
            });
        }

        function Reject(Id) {
            var reject = new Object();
            reject.RequestId = $('#id').val();
            reject.NIK = $('#nik').val();
            $.ajax({
                type: ""PUT"",
                url: '/ApproveManager/Reject',
                data: reject
            }).done((result) => {

                if (result == 200) {
                    swal('Success', 'Update Successfully', 'success');
                    $('#Request').modal('hide');
                 ");
                WriteLiteral(@"   $(""#id"").val(null);
                    $(""#nik"").val(null);
                    $(""#name"").val(null);
                    $(""#starthours"").val(null);
                    $(""#endhours"").val(null);
                    $(""#reason"").val(null);
                    $(""#payroll"").val(null);
                    table.ajax.reload();
                }
                else {
                    swal('Error', 'Something Went Wrong', 'error');
                }
            }).fail((error) => {
                console.log(error)
            });
        }
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
