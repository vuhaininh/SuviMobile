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

#line 1 "TextInput.cshtml"
using Suvi.Data;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class TextInput : System.Web.Mvc.WebViewPage<Suvi.Data.Question>
{

#line hidden

public override void Execute()
{
WriteLiteral("<div");

WriteLiteral(" class=\"question-message\"");

WriteLiteral(">\n  <div");

WriteLiteral(" class=\"question-input\"");

WriteLiteral(">\n    <textarea></textarea>\n  </div>\n  <div");

WriteLiteral(" class=\"message-action clearfix\"");

WriteLiteral(">\n    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary js-next\"");

WriteLiteral(">Next</button>\n  </div>\n</div>\n");

}
}
}
#pragma warning restore 1591
