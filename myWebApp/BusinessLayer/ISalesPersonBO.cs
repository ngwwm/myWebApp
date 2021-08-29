using myWebApp.Model;
using System.Collections.Generic;

namespace myWebApp.BusinessLayer
{
    public interface ISalesPersonBO
    {
        List<SalesPerson> GetSalesPersonData();
    }
}