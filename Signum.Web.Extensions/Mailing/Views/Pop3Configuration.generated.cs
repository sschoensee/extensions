﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.Mailing.Views
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
    
    #line 1 "..\..\Mailing\Views\Pop3Configuration.cshtml"
    using Signum.Entities.Mailing;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Mailing/Views/Pop3Configuration.cshtml")]
    public partial class Pop3Configuration : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Pop3Configuration()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Mailing\Views\Pop3Configuration.cshtml"
 using (var sc = Html.TypeContext<Pop3ConfigurationDN>())
{
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.Active));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.Port));

            
            #line default
            #line hidden
            
            #line 6 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                    
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.Host));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                    
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.Username));

            
            #line default
            #line hidden
            
            #line 8 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                        
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.Password, vl => vl.ValueHtmlProps.Add("type", "password")));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                                                                         
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.EnableSSL));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.ReadTimeout));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                           
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.ValueLine(sc, s => s.DeleteMessagesAfter));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                                   
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.EntityRepeater(sc, s => s.ClientCertificationFiles));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                                             

    if (!sc.Value.IsNew)
    {
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Mailing\Views\Pop3Configuration.cshtml"
Write(Html.CountSearchControl(new FindOptions(typeof(Pop3ReceptionDN))
    {
        FilterOptions = { new FilterOption("Pop3Configuration", sc.Value) }
    }, csc => { csc.PopupViewPrefix = sc.Compose("mm"); csc.WriteQueryName = WriteQueryName.FormGroup; }));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Mailing\Views\Pop3Configuration.cshtml"
                                                                                                     ;
    }
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
