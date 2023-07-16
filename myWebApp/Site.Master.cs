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
using Newtonsoft.Json;

namespace myWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var name = HttpContext.Current.User.Identity.Name;

            ClaimsPrincipal principal = HttpContext.Current.User as ClaimsPrincipal;
            string email = principal?.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;
            string appId = ConfigurationManager.AppSettings["Intercom:appId"];
            string userHash = "";

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
                    userHash = ByteArrayToHexString(hashBytes);
                }
            }

            var data = new
            {
                api_base = "https://api-iam.intercom.io",
                app_id = appId,
                name = name,
                email = email,
                user_hash = userHash
            };

            // Serialize the object to JSON
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            string script = $"window.intercomSettings = {json};";
            ScriptManager.RegisterStartupScript(this, GetType(), "IntercomSettingsScript", script, true);

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