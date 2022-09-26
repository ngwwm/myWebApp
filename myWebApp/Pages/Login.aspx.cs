using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWebApp.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = Request.QueryString["returnUrl"];
            
            HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
            {
                RedirectUri = returnUrl ?? "/"
            },
                       "Auth0");
            //return new HttpUnauthorizedResult();
            //return new HttpException(401, "Auth Failed");
        }
    }
}