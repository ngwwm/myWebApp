using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using myWebApp.DataAccessLayer.StackOverflow;
using myWebApp.Model;
using StackExchange.Redis;

namespace myWebApp.BusinessLayer
{
    public class UserBO : IUserBO
    {
        private IUserDO _userDO;
        private IConnectionMultiplexer _redisConn { get; set; }

        public UserBO(IUserDO userDO, IConnectionMultiplexer redisConn)
        {
            _userDO = userDO;
            _redisConn = redisConn;
        }
        //public List<SalesPerson> GetSalesPersonData()
        public List<StackOverflowUser> GetStackOverFlowUsers()
        {
            var list = new List<StackOverflowUser>();

            var db = _redisConn.GetDatabase();
            if (!db.StringGet("stackoverflowusers").IsNull )
            {
                using (IDataReader dr = _userDO.GetDataReader())
                {
                    while (dr.Read())
                    {
                        var p = new StackOverflowUser();

                        p.Id = (int)dr["Id"];
                        p.DisplayName = (string)(DBNull.Value.Equals(dr["DisplayName"]) ? string.Empty : dr["DisplayName"]);
                        p.Location = (string)(DBNull.Value.Equals(dr["Location"]) ? string.Empty : dr["Location"]);
                        p.UpVotes = (int)dr["UpVotes"];
                        p.DownVotes = (int)dr["DownVotes"];
                        p.Reputation = (int)dr["Reputation"];
                        p.WebsiteUrl = (string)(DBNull.Value.Equals(dr["WebsiteUrl"]) ? string.Empty : dr["WebsiteUrl"]);
                        p.CreationDate = (DateTime)dr["CreationDate"];
                        p.LastAccessDate = (DateTime)dr["LastAccessDate"];

                        list.Add(p);

                        var j = Newtonsoft.Json.JsonConvert.SerializeObject(p);

                        db.StringSet(p.Id.ToString(), j);
                    }
                    return list;
                }
            } else
            {
                var keys = _redisConn.GetServer(_redisConn.GetEndPoints()
                        .First())
                        .Keys(pattern: "*").ToList();

                foreach (var k in keys)
                {
                    StackOverflowUser p = Newtonsoft.Json.JsonConvert.DeserializeObject<StackOverflowUser>(db.StringGet(k.ToString()));
                    list.Add(p);
                }
                return list;
            }
        }
    }
}