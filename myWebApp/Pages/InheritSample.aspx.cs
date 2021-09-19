using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using myWebApp.BusinessLayer;
using myWebApp.DataLayer;
using System.Diagnostics;
using System.Configuration;
using myWebApp.Model;

namespace myWebApp.Pages
{
    public partial class InheritSample : System.Web.UI.Page
    {
        public IDatabase _database { get; set; }
        public ISalesPersonBO _salesPersonBO { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //ASP.NET Server Controls - https://docs.microsoft.com/en-us/troubleshoot/aspnet/server-controls
            Label1.Text = "(Precompiled): Page_Load fired!";
            Label1.Text += ToString();
            Label1.Text += Request.UserAgent;
            //Label1.Text += _database.GetVersion();

            CreateAssembly();

            ListSalesPersons();
        }

        private void ListSalesPersons()
        {
            //SalesPersonBO objBO = new SalesPersonBO();

            if (_salesPersonBO != null)
            {
                var data = _salesPersonBO.GetSalesPersonData();
                if (data is null)
                {
                    Debug.WriteLine("Oops");
                }
                else
                {
                    Debug.WriteLine(data.Count());
                    Label1.Text += $"\nThere are {data.Count()} records in xxx table.";
                    GridViewSalesPerson.DataSource = data;
                    GridViewSalesPerson.DataBind();
                }
            }
            var token = HttpContext.Current.Request.QueryString.Get("token");
            lblSessionId.Text = HttpContext.Current.Session.SessionID;
            lblServiceID.Text = ConfigurationManager.AppSettings["ServiceID"];
        }

        public List<SalesPerson> GetSalesPerson()
        {
            return _salesPersonBO.GetSalesPersonData();
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //_database.Disconnect();
            Debug.WriteLine("UnLoad");
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