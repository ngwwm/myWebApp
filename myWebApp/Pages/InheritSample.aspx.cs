using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using myWebApp.DataLayer;

namespace myWebApp.Pages
{
    public partial class InheritSample : System.Web.UI.Page
    {
        public IDatabase _database { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "(Precompiled): Page_Load fired!";
            Label1.Text += ToString();
            Label1.Text += Request.UserAgent;
            Label1.Text += _database.GetVersion();

            CreateAssembly();
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //_database.Disconnect();
        }

        private string fname = "Martin";
        private string lname = "NG";

        public override string ToString() => $"{fname} {lname}".Trim();

        private void CreateAssembly()
        {
            /*
            try
            {
                object db = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType("myWebApp.DataLayer.IDatabase)"));
            }
            */
        }
    }
}