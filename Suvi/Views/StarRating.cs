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

#line 1 "StarRating.cshtml"
using Suvi.Data;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class StarRating : System.Web.Mvc.WebViewPage<Suvi.Data.Question>
{

#line hidden

public override void Execute()
{
WriteLiteral("<div");

WriteLiteral(" class=\"question-rating\"");

WriteLiteral(">\n  <span");

WriteLiteral(" class=\"question-stars\"");

WriteLiteral(">\n");


#line 6 "StarRating.cshtml"
    

#line default
#line hidden

#line 6 "StarRating.cshtml"
     for(var i=5; i>0; i--)
    {


#line default
#line hidden
WriteLiteral("    \t<input");

WriteLiteral(" class=\"star-radio\"");

WriteLiteral(" type=\"radio\"");

WriteAttribute ("value", " value=\"", "\""

#line 8 "StarRating.cshtml"
               , Tuple.Create<string,object,bool> ("", i

#line default
#line hidden
, false)
);
WriteAttribute ("id", " id=\"", "\""

#line 8 "StarRating.cshtml"
                        , Tuple.Create<string,object,bool> ("", Model.ID + '-' + i

#line default
#line hidden
, false)
);
WriteAttribute ("name", " name=\"", "\""
, Tuple.Create<string,object,bool> ("", "question[", true)

#line 8 "StarRating.cshtml"
                                                             , Tuple.Create<string,object,bool> ("", Model.Index

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "]", true)
);
WriteLiteral(">\n");

WriteLiteral("    \t<label");

WriteLiteral(" class=\"star\"");

WriteAttribute ("for", " for=\"", "\""

#line 9 "StarRating.cshtml"
, Tuple.Create<string,object,bool> ("", Model.ID + '-' + i

#line default
#line hidden
, false)
);
WriteLiteral(">");


#line 9 "StarRating.cshtml"
                                                   Write(i);


#line default
#line hidden
WriteLiteral("</label>\n");


#line 10 "StarRating.cshtml"
  }


#line default
#line hidden
WriteLiteral("  </span>\n</div>\n");

}
}
}
#pragma warning restore 1591
