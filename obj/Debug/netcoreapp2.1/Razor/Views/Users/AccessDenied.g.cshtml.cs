#pragma checksum "C:\Users\Gustavo Passos\Desktop\Higher Diploma Science Computing\Guided Technology Project\Week 10\NewGerGarage\Ger_Garage\Ger_Garage\Views\Users\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a447cb0b0eb3eaa2983a2825cf590d4a9c978534"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_AccessDenied), @"mvc.1.0.view", @"/Views/Users/AccessDenied.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/AccessDenied.cshtml", typeof(AspNetCore.Views_Users_AccessDenied))]
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
#line 1 "C:\Users\Gustavo Passos\Desktop\Higher Diploma Science Computing\Guided Technology Project\Week 10\NewGerGarage\Ger_Garage\Ger_Garage\Views\_ViewImports.cshtml"
using Ger_Garage;

#line default
#line hidden
#line 2 "C:\Users\Gustavo Passos\Desktop\Higher Diploma Science Computing\Guided Technology Project\Week 10\NewGerGarage\Ger_Garage\Ger_Garage\Views\_ViewImports.cshtml"
using Ger_Garage.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a447cb0b0eb3eaa2983a2825cf590d4a9c978534", @"/Views/Users/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba87cfbe6ecd17c022472112ce5de045bd23cc02", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ger_Garage.Models.User>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Gustavo Passos\Desktop\Higher Diploma Science Computing\Guided Technology Project\Week 10\NewGerGarage\Ger_Garage\Ger_Garage\Views\Users\AccessDenied.cshtml"
  
	ViewData["Title"] = "Access Denied";

#line default
#line hidden
            BeginContext(77, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(79, 350, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e9001b2557b41e097f702daf7293c18", async() => {
                BeginContext(85, 337, true);
                WriteLiteral(@"
	<div class=""container"">
		<div class=""row"">
			<div class=""col-sm-9 col-md-7 col-lg-5 mx-auto"">
				<div class=""card card-signin my-5"">
					<div class=""card-body"">
						<h5 class=""card-title text-center"">You don't have enough permission to access this page.</h5>
						
					</div>
				</div>
			</div>
		</div>
	</div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(429, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ger_Garage.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
