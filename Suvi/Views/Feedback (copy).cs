#pragma warning disable 1591
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Suvi
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 1 "Feedback.cshtml"
using MVCPolyfils;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class Feedback : System.Web.Mvc.WebViewPage<Suvi.Data.Feedback>
{

#line hidden

public override void Execute()
{
WriteLiteral("<html");

WriteLiteral(" lang=\"en\"");

WriteLiteral(" xmlns=\"http://www.w3.org/1999/xhtml\"");

WriteLiteral("\n      xmlns:fb=\"http://ogp.me/ns/fb#\"");

WriteLiteral(">\n<head>\n  \n  <title>Survey in Pocket</title>\n  <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable" +
"=no\"");

WriteLiteral(">\n  <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"Content/bootstrap.min.css\"");

WriteLiteral(" />\n  <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"Content/font-awesome.min.css\"");

WriteLiteral(" />\n  \n</head>\n<body>\n\n");

WriteLiteral("\t");


#line 16 "Feedback.cshtml"
Write(Html.Partial("Suvi.Header, Suvi", null));


#line default
#line hidden
WriteLiteral("\n");

WriteLiteral("\t");


#line 17 "Feedback.cshtml"
Write(Html.Partial("Suvi.Question, Suvi", new Suvi.Data.Question{
		QuestionText = "This is a sample question", 
		QuestionType = Suvi.Data.QuestionType.Image 
	}));


#line default
#line hidden
WriteLiteral("\n");

WriteLiteral("    ");


#line 21 "Feedback.cshtml"
Write(Html.Partial("Suvi.Footer, Suvi", null));


#line default
#line hidden
WriteLiteral("\n</body>\n</html>\n");

}
}
}
#pragma warning restore 1591
