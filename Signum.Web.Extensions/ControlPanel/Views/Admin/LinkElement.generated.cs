﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.ControlPanel.Views.Admin
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Signum.Entities;
    
    #line 1 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
    using Signum.Entities.ControlPanel;
    
    #line default
    #line hidden
    
    #line 3 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
    using Signum.Entities.Reports;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 2 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
    using Signum.Web.ControlPanel;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ControlPanel/Views/Admin/LinkElement.cshtml")]
    public partial class LinkElement : System.Web.Mvc.WebViewPage<dynamic>
    {
        public LinkElement()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
 using (var tc = Html.TypeContext<LinkElementDN>())
{
    tc.FormGroupStyle = FormGroupStyle.None;
    using (Html.FormInline())
    {
        
            
            #line default
            #line hidden
            
            #line 10 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
   Write(Html.ValueLine(tc, l => l.Label));

            
            #line default
            #line hidden
            
            #line 10 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
                                         
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
   Write(Html.ValueLine(tc, l => l.Link));

            
            #line default
            #line hidden
            
            #line 11 "..\..\ControlPanel\Views\Admin\LinkElement.cshtml"
                                        
    }
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
