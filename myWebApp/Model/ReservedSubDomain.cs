using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWebApp.Model
{
    public class ReservedSubDomain 
    {
        public string SubDomain { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDtm { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDtm { get; set; }
    }
}