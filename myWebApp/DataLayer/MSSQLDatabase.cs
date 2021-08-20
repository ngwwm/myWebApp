using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWebApp.DataLayer;
using System.Data.SqlClient;

namespace myWebApp.DataLayer
{
    public class MSSQLDatabase : IDatabase
    {
        private string Vendor = "MSSQL";
        private string Version = "2016 SP2";
        private string connStr = "Server=localhost;Database=AdventureWorks2019;Trusted_Connection=True; min pool size=5";
        private SqlConnection objConn;

        public MSSQLDatabase()
        {
            Console.WriteLine("Constructor");
            if (objConn == null)
            {
                try
                {
                    objConn = new SqlConnection(connStr);
                    objConn.Open();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Connect()
        {
            Console.WriteLine("Connected");
        }
        public void Connect(string connectionString)
        {
            if (objConn == null)
            {
                try
                {
                    objConn = new SqlConnection(connectionString);

                    objConn.Open();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            Console.WriteLine("Connected");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnected");
            if (objConn != null && objConn.State == System.Data.ConnectionState.Open)
            {
                objConn.Close();
            } else
            {
                objConn = null;
            }
        }

        public string GetVersion()
        {
            return $"{Vendor} {Version}";
        }
    }
}