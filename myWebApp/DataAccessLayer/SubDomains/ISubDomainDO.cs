using myWebApp.DataLayer;
using System.Data;

namespace myWebApp.DataAccessLayer.SubDomains
{
    public interface ISubDomainDO
    {
        IRDBMSDatabase _db { get; set; }

        IDataReader GetDataReader();
    }
}