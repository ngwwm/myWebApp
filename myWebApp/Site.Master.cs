using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace myWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsername.Text = HttpContext.Current.User.Identity.Name;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                lnkLogin.Visible = false;
                lnkLogout.Visible = !lnkLogin.Visible;
            }
            else
            {
                lnkLogin.Visible = true;
                lnkLogout.Visible = !lnkLogin.Visible;
            }
        }
    }
}