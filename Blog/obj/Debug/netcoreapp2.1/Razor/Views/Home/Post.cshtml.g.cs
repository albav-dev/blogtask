#pragma checksum "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32ce552bfa9b3d5bdc0709227f0b2f5f7ae6a49b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Post), @"mvc.1.0.view", @"/Views/Home/Post.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Post.cshtml", typeof(AspNetCore.Views_Home_Post))]
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
#line 1 "C:\Users\User\Documents\Extra\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.Models;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\Extra\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.Models.Comments;

#line default
#line hidden
#line 3 "C:\Users\User\Documents\Extra\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32ce552bfa9b3d5bdc0709227f0b2f5f7ae6a49b", @"/Views/Home/Post.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"589cc89b1f87f47cabbc31f53b279948e21071bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Post : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(13, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
   
    ViewBag.Title = Model.Title;
    ViewBag.Description = Model.Description;
    ViewBag.Keywords = $"{Model.Tags?.Replace(",", "")} {Model.Category}";
    var base_path = Context.Request.PathBase;

#line default
#line hidden
            BeginContext(226, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(405, 61, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"post no-shadow\">\r\n");
            EndContext();
#line 22 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
         if (!String.IsNullOrEmpty(Model.Image))
        {
            var image_path = $"{base_path}/Image/{Model.Image}";

#line default
#line hidden
            BeginContext(593, 16, true);
            WriteLiteral("            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 609, "\"", 626, 1);
#line 25 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
WriteAttributeValue("", 615, image_path, 615, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(627, 37, true);
            WriteLiteral(" />\r\n            <span class=\"title\">");
            EndContext();
            BeginContext(665, 11, false);
#line 26 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
                           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(676, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 27 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
        }

#line default
#line hidden
            BeginContext(696, 49, true);
            WriteLiteral("    </div>\r\n    <div class=\"post-body\">\r\n        ");
            EndContext();
            BeginContext(746, 20, false);
#line 30 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
   Write(Html.Raw(Model.Body));

#line default
#line hidden
            EndContext();
            BeginContext(766, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 32 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
            BeginContext(828, 39, true);
            WriteLiteral("        <div class=\"comment-section\">\r\n");
            EndContext();
#line 35 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
              
                await Html.RenderPartialAsync("_MainComment", new CommentViewModel { PostId = Model.Id, MainCommentId = 0 });
            

#line default
#line hidden
            BeginContext(1025, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 39 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
             foreach (var c in Model.MainComments)
            {

#line default
#line hidden
            BeginContext(1094, 41, true);
            WriteLiteral("                <p>\r\n                    ");
            EndContext();
            BeginContext(1136, 9, false);
#line 42 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
               Write(c.Message);

#line default
#line hidden
            EndContext();
            BeginContext(1145, 5, true);
            WriteLiteral(" --- ");
            EndContext();
            BeginContext(1151, 9, false);
#line 42 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
                              Write(c.Created);

#line default
#line hidden
            EndContext();
            BeginContext(1160, 117, true);
            WriteLiteral("\r\n                </p>\r\n                <div style=\"margin-left: 20px;\">\r\n                    <h4>Sub Comments</h4>\r\n");
            EndContext();
#line 46 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
                      
                        await Html.RenderPartialAsync("_MainComment", new CommentViewModel { PostId = Model.Id, MainCommentId = c.Id });
                    

#line default
#line hidden
            BeginContext(1462, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 50 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
                     foreach (var sc in c.SubComments)
                    {

#line default
#line hidden
            BeginContext(1543, 57, true);
            WriteLiteral("                        <p>\r\n                            ");
            EndContext();
            BeginContext(1601, 10, false);
#line 53 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
                       Write(sc.Message);

#line default
#line hidden
            EndContext();
            BeginContext(1611, 5, true);
            WriteLiteral(" --- ");
            EndContext();
            BeginContext(1617, 10, false);
#line 53 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
                                       Write(sc.Created);

#line default
#line hidden
            EndContext();
            BeginContext(1627, 32, true);
            WriteLiteral("\r\n                        </p>\r\n");
            EndContext();
#line 55 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
                    }

#line default
#line hidden
            BeginContext(1682, 24, true);
            WriteLiteral("                </div>\r\n");
            EndContext();
#line 57 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
            }

#line default
#line hidden
            BeginContext(1721, 16, true);
            WriteLiteral("        </div>\r\n");
            EndContext();
#line 59 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1761, 27, true);
            WriteLiteral("        <div>\r\n            ");
            EndContext();
            BeginContext(1788, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9aa6164955f403d997b5f2b971282d1", async() => {
                BeginContext(1832, 15, true);
                WriteLiteral("<i>Sign In</i> ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1851, 43, true);
            WriteLiteral(" to comment on this post.\r\n        </div>\r\n");
            EndContext();
#line 65 "C:\Users\User\Documents\Extra\Blog\Blog\Views\Home\Post.cshtml"
    }

#line default
#line hidden
            BeginContext(1901, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
