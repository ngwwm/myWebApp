using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace myWebApp.DataLayer
{
    public interface IDatabase 
    {
        IDbConnection _conn { get; set; }

        void Connect();
        void Disconnect();
        string GetVersion();
    }
}
