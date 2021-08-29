using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWebApp.Model
{
    public class SalesPerson
    {
        public int BusinessEntityID { get; set; }
        public string Title { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public float SalesYTD{ get; set; }
    }
}