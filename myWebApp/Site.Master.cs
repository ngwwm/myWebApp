using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace myWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var name = HttpContext.Current.User.Identity.Name;

            ClaimsPrincipal principal = HttpContext.Current.User as ClaimsPrincipal;
            var email = principal?.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;

            userName.Text = name;
            userEmail.Text = email;
            lblUsername.Text = $"{name} &lt;{email}&gt;";

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
            if (email != null)
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Intercom:secretKey"]);
                byte[] messageBytes = Encoding.UTF8.GetBytes(email);

                using (HMACSHA256 hmacSha256 = new HMACSHA256(keyBytes))
                {
                    byte[] hashBytes = hmacSha256.ComputeHash(messageBytes);
                    //userHash.Text = Convert.ToBase64String(hashBytes);
                    userHash.Text = ByteArrayToHexString(hashBytes);
                }
            }
        }
        public static string ByteArrayToHexString(byte[] byteArray)
        {
            StringBuilder hexBuilder = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
            {
                hexBuilder.AppendFormat("{0:x2}", b);
            }
            return hexBuilder.ToString();
        }
    }
}