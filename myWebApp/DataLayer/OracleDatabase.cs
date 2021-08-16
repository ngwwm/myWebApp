using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWebApp.DataLayer;

namespace myWebApp.DataLayer
{
    public class OracleDatabase : IDatabase
    {
        private string Vendor = "Oracle";
        private string Version = "19c";

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