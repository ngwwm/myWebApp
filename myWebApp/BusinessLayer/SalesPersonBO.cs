using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using myWebApp.DataAccessLayer.Sales;
using myWebApp.Model;
using myWebApp.DataLayer;
using StackExchange.Redis;

namespace myWebApp.BusinessLayer
{

    public class SalesPersonBO : ISalesPersonBO
    {
        //public IDatabase _db { get; set; }

        public ISalesPersonDO _salesPersonDO { get; set; }
        public IConnectionMultiplexer _redisCache { get; set; }
        public SalesPersonBO(ISalesPersonDO salesPersonDO, IConnectionMultiplexer redisCache)
        {
            Console.WriteLine("SalesPersonBO Ctor");
            _salesPersonDO = salesPersonDO;
            _redisCache = redisCache;
        }
        public List<SalesPerson> GetSalesPersonData()
        {
            //var salesPersonDO = new SalesPersonDO();
            var list = new List<SalesPerson>();

            var db = _redisCache.GetDatabase();
            var foo = db.StringGet("foo");

            using (IDataReader sdr = _salesPersonDO.GetSalesPersonDataReader())
            {
                while (sdr.Read())
                {
                    var p = new SalesPerson();

                    p.BusinessEntityID = (int)sdr["BusinessEntityID"];
                    p.Title = (string)(DBNull.Value.Equals(sdr["Title"]) ? string.Empty : sdr["Title"]);
                    p.FirstName = (string)sdr["FirstName"];
                    p.LastName = (string)sdr["LastName"];

                    list.Add(p);
                }
                return list;
            }
        }

    }


}