using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using myWebApp.DataLayer;
using myWebApp.Model;

namespace myWebApp.DataAccessLayer.SubDomains
{
    public class SubDomainDO : ISubDomainDO
    {
        public IRDBMSDatabase _db { get; set; }

        public SubDomainDO(IRDBMSDatabase db)
        {
            Console.WriteLine("SubDomainDO Ctor");
            _db = db;
        }

        public IDataReader GetDataReader()
        {

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [MstAppl].[ReservedSubDomain]", (SqlConnection)_db._conn))
            {
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteReader();
            }
        }
    }
}