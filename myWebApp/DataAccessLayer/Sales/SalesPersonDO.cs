using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using myWebApp.DataLayer;
using myWebApp.Model;

namespace myWebApp.DataAccessLayer.Sales
{
    public class SalesPersonDO : ISalesPersonDO
    {
        public IDatabase _db { get; set; }

        public SalesPersonDO(IDatabase db)
        {
            Console.WriteLine("SalesPersonDO Ctor");
            _db = db;
        }

        public IDataReader GetSalesPersonDataReader()
        {

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Sales].[vSalesPerson]", (SqlConnection)_db._conn))
            {
                List<SalesPerson> salesPersons = new List<SalesPerson>();
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteReader();
                /*
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        salesPersons.Add(new SalesPerson
                        {
                            BusinessEntityID = Convert.ToInt32(sdr["BusinessEntityID"]),
                            Title = sdr["Title"].ToString(),
                            FirstName = sdr["FirstName"].ToString(),
                            LastName = sdr["LastName"].ToString()
                        });
                    }
                    return sdr;
                }
                */
            }
        }
    }
}