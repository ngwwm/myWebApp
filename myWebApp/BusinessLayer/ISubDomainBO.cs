using myWebApp.Model;
using System.Collections.Generic;

namespace myWebApp.BusinessLayer
{
    public interface ISubDomainBO
    {
        List<ReservedSubDomain> GetSubDomains();
    }
}