using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWebApp.DataLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using myLogger;

namespace myWebApp.DataLayer
{
    public class MSSQLDatabase : IRDBMSDatabase, IDisposable
    {
        private string Vendor = "MSSQL";
        private string Version = "2016 SP2";
        private string connStr = ""; //"Server=localhost;Database=AdventureWorks2019;Trusted_Connection=True; min pool size=3; Application Name=WebApp";
        public IDbConnection _conn { set; get; }

        public MSSQLDatabase()
        {
            Console.WriteLine("Constructor");

            connStr = ConfigurationManager.AppSettings["DbConnectionString"];
            if (_conn == null)
            {
                try
                {
                    _conn = new SqlConnection(connStr);
                    _conn.Open();
                } catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    myLog.mlog.Error(ex.Message);
                }
                finally
                {
                    myLog.mlog.Debug("MSSQLDatabase: connection opened.");
                }
            }
        }

        public void Connect()
        {
            Debug.WriteLine("_connected");
        }
        public void Connect(string connectionString)
        {
            if (_conn == null)
            {
                try
                {
                    _conn = new SqlConnection(connectionString);

                    _conn.Open();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            Console.WriteLine("_connected");
        }

        public void Dispose()
        {
            Disconnect();
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnected");
            if (_conn != null && _conn.State == ConnectionState.Open)
            {
                _conn.Close();
            } else
            {
                _conn = null;
            }
        }

        public string GetVersion()
        {
            return $"{Vendor} {Version}";
        }
    }
}