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
    public partial class SubDomains: System.Web.UI.Page
    {
        public ISubDomainBO _subDomainBO { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Page_Load: SubDomains");
        }

        public List<ReservedSubDomain> GetSubDomains()
        {
            return _subDomainBO.GetSubDomains();
        }
    }
}