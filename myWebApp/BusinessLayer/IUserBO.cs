using myWebApp.Model;
using System.Collections.Generic;

namespace myWebApp.BusinessLayer
{
    public interface IUserBO
    {
        List<StackOverflowUser> GetStackOverFlowUsers();
    }
}