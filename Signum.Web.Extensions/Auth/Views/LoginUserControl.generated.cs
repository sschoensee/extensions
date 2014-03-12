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

namespace Signum.Web.Extensions.Auth.Views
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
    using Signum.Entities.Authorization;
    using Signum.Utilities;
    using Signum.Web;
    using Signum.Web.Auth;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Auth/Views/LoginUserControl.cshtml")]
    public partial class LoginUserControl : System.Web.Mvc.WebViewPage<dynamic>
    {
        public LoginUserControl()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Auth\Views\LoginUserControl.cshtml"
 if (UserDN.Current != null && !UserDN.Current.Is(Signum.Engine.Authorization.AuthLogic.AnonymousUser) )
{   
    
            
            #line default
            #line hidden
            
            #line 3 "..\..\Auth\Views\LoginUserControl.cshtml"
Write(Html.ActionLink(AuthMessage.Logout.NiceToString() + " " + UserDN.Current, "Logout" , "Auth", null, new { @class = "sf-logout" }));

            
            #line default
            #line hidden
            
            #line 3 "..\..\Auth\Views\LoginUserControl.cshtml"
                                                                                                                                     
}
else
{ 
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\Auth\Views\LoginUserControl.cshtml"
Write(Html.ActionLink(AuthMessage.Login.NiceToString(), "Login", "Auth", null, new { @class = "sf-login" }));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Auth\Views\LoginUserControl.cshtml"
                                                                                                          
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
