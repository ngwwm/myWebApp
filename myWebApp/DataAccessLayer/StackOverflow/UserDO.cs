using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using myWebApp.DataLayer;

namespace myWebApp.DataAccessLayer.StackOverflow
{
    public class UserDO : IUserDO
    {
        private IRDBMSDatabase _db { get; set; }
        public UserDO(IRDBMSDatabase db)
        {
            _db = db;
        }
        public IDataReader GetDataReader()
        {
            string stmt = @"SELECT top 10 Id, DisplayName, Location, UpVotes, DownVotes, 
                            CreationDate, LastAccessDate, Reputation, Views, WebsiteUrl 
                            FROM dbo.Users order by Upvotes desc";

            using (SqlCommand cmd = new SqlCommand(stmt, (SqlConnection)_db._conn))
            {
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteReader();
            }
        }
    }
}