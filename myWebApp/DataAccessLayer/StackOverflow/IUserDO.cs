using System.Data;

namespace myWebApp.DataAccessLayer.StackOverflow
{
    public interface IUserDO
    {
        IDataReader GetDataReader();
    }
}