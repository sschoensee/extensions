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
    
    #line 1 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
    using Signum.Entities.ControlPanel;
    
    #line default
    #line hidden
    
    #line 3 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
    using Signum.Entities.Reports;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 2 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
    using Signum.Web.ControlPanel;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/ControlPanel/Views/Admin/PanelPartView.cshtml")]
    public partial class PanelPartView : System.Web.Mvc.WebViewPage<dynamic>
    {
        public PanelPartView()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
 using (var tc = Html.TypeContext<PanelPartDN>())
{
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
Write(Html.HiddenRuntimeInfo(tc));

            
            #line default
            #line hidden
            
            #line 7 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
                               
    var part = tc.Value;

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"ui-widget ui-widget-content ui-corner-all sf-ftbl-part\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ui-widget-header ui-corner-all sf-ftbl-part-header\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" class=\"sf-line-button sf-remove\"");

WriteLiteral(" data-icon=\"ui-icon-circle-close\"");

WriteLiteral(" data-text=\"false\"");

WriteLiteral("></button>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
       Write(Html.ValueLine(tc, pp => pp.Title, vl => vl.FormGroupStyle = FormGroupStyle.None));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div>\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
       Write(Html.HiddenRuntimeInfo(tc, pp => pp.Content));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
       Write(Html.EmbeddedControl(tc, pp => pp.Content, ecs => ecs.ViewName = ControlPanelClient.PanelPartViews[part.Content.GetType()].Admin));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div>\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
       Write(Html.Hidden(tc.Compose("Row"), part.Row, new { @class = "sf-ftbl-part-row" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
       Write(Html.Hidden(tc.Compose("Column"), part.Column, new { @class = "sf-ftbl-part-col" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

            
            #line 23 "..\..\ControlPanel\Views\Admin\PanelPartView.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
