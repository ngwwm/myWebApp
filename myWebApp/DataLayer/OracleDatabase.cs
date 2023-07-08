using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWebApp.DataLayer;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace myWebApp.DataLayer
{
    public class OracleDatabase : IRDBMSDatabase
    {
        private readonly string Vendor = "Oracle";
        private readonly string Version = "19c";
        public IDbConnection _conn { set; get; }

        public void Connect()
        {
            Console.WriteLine("Connected");
        }
        public void Disconnect()
        {
            Console.WriteLine("Disconnected");
        }

        public string GetVersion()
        {
            return $"{Vendor} {Version}";
        }
    }
}