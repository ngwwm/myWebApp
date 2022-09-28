using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.Cookies;

namespace myWebApp.Pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            HttpContext.Current.GetOwinContext().Authentication.SignOut("Auth0");
        }
    }
}