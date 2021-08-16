using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWebApp.DataLayer;

namespace myWebApp.DataLayer
{
    public class MSSQLDatabase : IDatabase
    {
        private string Vendor = "MSSQL";
        private string Version = "2016 SP2";

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