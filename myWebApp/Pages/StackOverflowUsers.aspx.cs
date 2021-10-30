using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWebApp.BusinessLayer;
using myWebApp.Model;

namespace myWebApp.Pages
{
    public partial class StackOverflowUsers : System.Web.UI.Page
    {
        public IUserBO _userBO { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            myLogger.myLog.mlog.Info("StackOverflowUsers Page_Load.");
            Debug.WriteLine("Page_Load: StackOverflowUsers");
        }


        public List<StackOverflowUser> GetUsers()
        {
            return _userBO.GetStackOverFlowUsers();
        }
    }
}