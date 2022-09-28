using System.Data;

namespace myWebApp.DataAccessLayer.Sales
{
    public interface ISalesPersonDO
    {
        IDataReader GetSalesPersonDataReader();
    }
}