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

#line 1 "MultipleChoice.cshtml"
using Suvi.Data;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class MultipleChoice : System.Web.Mvc.WebViewPage<Suvi.Data.Question>
{

#line hidden

public override void Execute()
{
WriteLiteral("<div");

WriteLiteral(" class=\"question-choices\"");

WriteLiteral(" data-col=\"1\"");

WriteLiteral(">\n\n");


#line 6 "MultipleChoice.cshtml"
 if(Model.AllowMultipleChoice)
{
	foreach (var choice in @Model.Choices) {


#line default
#line hidden
WriteLiteral("\t\t<span");

WriteLiteral(" class=\"question-choice\"");

WriteLiteral(">\n\t          <input");

WriteLiteral(" class=\"input-checkbox\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute ("value", " value=\"", "\""

#line 10 "MultipleChoice.cshtml"
                            , Tuple.Create<string,object,bool> ("", choice.Label

#line default
#line hidden
, false)
);
WriteAttribute ("id", " id=\"", "\""

#line 10 "MultipleChoice.cshtml"
                                                , Tuple.Create<string,object,bool> ("", Model.ID + '-' + choice.ID

#line default
#line hidden
, false)
);
WriteAttribute ("name", " name=\"", "\""
, Tuple.Create<string,object,bool> ("", "question[", true)

#line 10 "MultipleChoice.cshtml"
                                                                                             , Tuple.Create<string,object,bool> ("", Model.Index

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "]", true)
);
WriteLiteral("/>\n\t          <label");

WriteLiteral(" class=\"btn\"");

WriteAttribute ("for", " for=\"", "\""

#line 11 "MultipleChoice.cshtml"
, Tuple.Create<string,object,bool> ("", Model.ID + '-' + choice.ID

#line default
#line hidden
, false)
);
WriteLiteral(">");


#line 11 "MultipleChoice.cshtml"
                                                                Write(choice.Label);


#line default
#line hidden
WriteLiteral("</label>\n\t        </span>\n");


#line 13 "MultipleChoice.cshtml"
	}
}
else
{
	foreach (var choice in @Model.Choices) {


#line default
#line hidden
WriteLiteral("\t\t<span");

WriteLiteral(" class=\"question-choice\"");

WriteLiteral(">\n\t          <input");

WriteLiteral(" class=\"input-radio\"");

WriteLiteral(" type=\"radio\"");

WriteAttribute ("value", " value=\"", "\""

#line 19 "MultipleChoice.cshtml"
                      , Tuple.Create<string,object,bool> ("", choice.Label

#line default
#line hidden
, false)
);
WriteAttribute ("id", " id=\"", "\""

#line 19 "MultipleChoice.cshtml"
                                          , Tuple.Create<string,object,bool> ("", Model.ID + '-' + choice.ID

#line default
#line hidden
, false)
);
WriteAttribute ("name", " name=\"", "\""
, Tuple.Create<string,object,bool> ("", "question[", true)

#line 19 "MultipleChoice.cshtml"
                                                                                       , Tuple.Create<string,object,bool> ("", Model.Index

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "]", true)
);
WriteLiteral("/>\n\t          <label");

WriteLiteral(" class=\"btn\"");

WriteAttribute ("for", " for=\"", "\""

#line 20 "MultipleChoice.cshtml"
, Tuple.Create<string,object,bool> ("", Model.ID + '-' + choice.ID

#line default
#line hidden
, false)
);
WriteLiteral(">");


#line 20 "MultipleChoice.cshtml"
                                                                Write(choice.Label);


#line default
#line hidden
WriteLiteral("</label>\n\t        </span>\n");


#line 22 "MultipleChoice.cshtml"
	}
}


#line default
#line hidden
WriteLiteral("\n</div>\n\n\n");


#line 28 "MultipleChoice.cshtml"
 if(Model.AllowMultipleChoice)
{


#line default
#line hidden
WriteLiteral("\t<div");

WriteLiteral(" class=\"question-message\"");

WriteLiteral(">\n\t  <div");

WriteLiteral(" class=\"message-action clearfix\"");

WriteLiteral(">\n\t    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary js-next\"");

WriteLiteral(">Next</button>\n\t  </div>\n\t</div>\n");


#line 35 "MultipleChoice.cshtml"
}


#line default
#line hidden
WriteLiteral("\t\t\n");

}
}
}
#pragma warning restore 1591
