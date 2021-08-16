using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWebApp.DataLayer
{
    public interface IDatabase
    {
        void Connect();
        void Disconnect();
        string GetVersion();
    }
}
