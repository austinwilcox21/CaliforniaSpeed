<<<<<<< HEAD
#pragma checksum "/Users/awilcox/Documents/GitHub/Hello World/CaliforniaSpeed/TestWebSocketApplication/Views/Shared/Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ecc4d2bcad30a6aee551879bc7e7094ebb4184d"
=======
#pragma checksum "C:\Users\Juan\Documents\GitHub\CaliforniaSpeed\TestWebSocketApplication\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6a5625cc8fb4476f348b0fe9041c550465d8bf9"
>>>>>>> 1120f9c871725560823d9a576e14ad7052c739bf
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
<<<<<<< HEAD
#line 1 "/Users/awilcox/Documents/GitHub/Hello World/CaliforniaSpeed/TestWebSocketApplication/Views/_ViewImports.cshtml"
=======
#line 1 "C:\Users\Juan\Documents\GitHub\CaliforniaSpeed\TestWebSocketApplication\Views\_ViewImports.cshtml"
>>>>>>> 1120f9c871725560823d9a576e14ad7052c739bf
using TestWebSocketApplication;

#line default
#line hidden
<<<<<<< HEAD
#line 2 "/Users/awilcox/Documents/GitHub/Hello World/CaliforniaSpeed/TestWebSocketApplication/Views/_ViewImports.cshtml"
=======
#line 2 "C:\Users\Juan\Documents\GitHub\CaliforniaSpeed\TestWebSocketApplication\Views\_ViewImports.cshtml"
>>>>>>> 1120f9c871725560823d9a576e14ad7052c739bf
using TestWebSocketApplication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ecc4d2bcad30a6aee551879bc7e7094ebb4184d", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc12b99815e17ba2345f356c15e83ae175dbd5bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
<<<<<<< HEAD
#line 2 "/Users/awilcox/Documents/GitHub/Hello World/CaliforniaSpeed/TestWebSocketApplication/Views/Shared/Error.cshtml"
=======
#line 2 "C:\Users\Juan\Documents\GitHub\CaliforniaSpeed\TestWebSocketApplication\Views\Shared\Error.cshtml"
>>>>>>> 1120f9c871725560823d9a576e14ad7052c739bf
  
    ViewData["Title"] = "Error";

#line default
#line hidden
            BeginContext(60, 116, true);
            WriteLiteral("\n<h1 class=\"text-danger\">Error.</h1>\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\n\n");
            EndContext();
<<<<<<< HEAD
#line 9 "/Users/awilcox/Documents/GitHub/Hello World/CaliforniaSpeed/TestWebSocketApplication/Views/Shared/Error.cshtml"
=======
#line 9 "C:\Users\Juan\Documents\GitHub\CaliforniaSpeed\TestWebSocketApplication\Views\Shared\Error.cshtml"
>>>>>>> 1120f9c871725560823d9a576e14ad7052c739bf
 if (Model.ShowRequestId)
{

#line default
#line hidden
            BeginContext(204, 51, true);
            WriteLiteral("    <p>\n        <strong>Request ID:</strong> <code>");
            EndContext();
<<<<<<< HEAD
            BeginContext(256, 15, false);
#line 12 "/Users/awilcox/Documents/GitHub/Hello World/CaliforniaSpeed/TestWebSocketApplication/Views/Shared/Error.cshtml"
=======
            BeginContext(267, 15, false);
#line 12 "C:\Users\Juan\Documents\GitHub\CaliforniaSpeed\TestWebSocketApplication\Views\Shared\Error.cshtml"
>>>>>>> 1120f9c871725560823d9a576e14ad7052c739bf
                                      Write(Model.RequestId);

#line default
#line hidden
            EndContext();
            BeginContext(271, 17, true);
            WriteLiteral("</code>\n    </p>\n");
            EndContext();
<<<<<<< HEAD
#line 14 "/Users/awilcox/Documents/GitHub/Hello World/CaliforniaSpeed/TestWebSocketApplication/Views/Shared/Error.cshtml"
=======
#line 14 "C:\Users\Juan\Documents\GitHub\CaliforniaSpeed\TestWebSocketApplication\Views\Shared\Error.cshtml"
>>>>>>> 1120f9c871725560823d9a576e14ad7052c739bf
}

#line default
#line hidden
            BeginContext(290, 566, true);
            WriteLiteral(@"
<h3>Development Mode</h3>
<p>
    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
