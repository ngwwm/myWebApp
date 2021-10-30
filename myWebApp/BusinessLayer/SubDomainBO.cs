using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using myWebApp.DataAccessLayer.SubDomains;
using myWebApp.Model;
using StackExchange.Redis;

namespace myWebApp.BusinessLayer
{
    public class SubDomainBO : ISubDomainBO
    {
        private ISubDomainDO _SubDomainDO;
        private IConnectionMultiplexer _redisConn { get; set; }
        public SubDomainBO(ISubDomainDO SubDomainDO)
        {
            _SubDomainDO = SubDomainDO;
        }
        public SubDomainBO(ISubDomainDO SubDomainDO, IConnectionMultiplexer redisConn)
        {
            _SubDomainDO = SubDomainDO;
            _redisConn = redisConn;
        }
        public List<ReservedSubDomain> GetSubDomains()
        {
            var list = new List<ReservedSubDomain>();

            {
                using (IDataReader dr = _SubDomainDO.GetDataReader())
                {
                    while (dr.Read())
                    {
                        var p = new ReservedSubDomain
                        {
                            SubDomain = (string)(DBNull.Value.Equals(dr["SubDomain"]) ? string.Empty : dr["SubDomain"]),
                            CompanyId = (int)dr["CompanyId"],
                            IsDeleted = (bool)dr["IsDeleted"],
                            CreatedDtm = (DateTime)(DBNull.Value.Equals(dr["CreatedDtm"]) ? 0 : dr["CreatedDtm"])
                        };
                        //p.UpdatedDtm = (DateTime)(DBNull.Value.Equals(dr["UpdatedDtm"]) ? '19000 : dr["UpdatedDtm"]);

                        list.Add(p);
                    }
                    return list;
                }
            }
        }
    }
}