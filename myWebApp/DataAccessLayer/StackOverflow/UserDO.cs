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
            string stmt = @"select top 10 UserId as Id, FirstName as DisplayName, LastName as Location, 0 as UpVotes, 0 as DownVotes, 
                            CreatedDtm as CreationDate, UpdatedDtm as LastAccessDate, 0 as Reputation, 0 as Views, EmailId as WebsiteUrl 
                            FROM [User].[LoginDetail]";

            using (SqlCommand cmd = new SqlCommand(stmt, (SqlConnection)_db._conn))
            {
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteReader();
            }
        }
    }
}