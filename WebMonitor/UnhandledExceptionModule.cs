using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;

namespace WebMonitor
{

    public class UnhandledExceptionModule : IHttpModule
    {
        static int _unhandledExceptionCount = 0;
        static object _initLock = new object();
        static bool _initialized = false;

        public void Init(HttpApplication app)
        {
            // Do this one time for each AppDomain.  Verify that we’re on the correct ASP.NET version and
            // that the EventLog has been properly configured.  If all is well, register an event handler for
            // unhandled exceptions.
            if (!_initialized)
            {
                lock (_initLock)
                {
                    if (!_initialized)
                    {
                        AppDomain.CurrentDomain.UnhandledException +=
                              new UnhandledExceptionEventHandler(OnUnhandledException);

                        _initialized = true;
                    }
                }
            }
        }

        public void Dispose()
        { }

        void OnUnhandledException(object o, UnhandledExceptionEventArgs e)
        {
            // Let this occur one time for each AppDomain.
            if (Interlocked.Exchange(ref _unhandledExceptionCount, 1) != 0) return;

            // Build a message containing the exception details
            StringBuilder message = new StringBuilder("\r\n\r\nUnhandledException logged by UnhandledExceptionModule.dll:\r\n\r\nappId = ");
            string appId = (string)AppDomain.CurrentDomain.GetData(".appId");
            if (appId != null) message.Append(appId);

            Exception currentException = null;
            for (currentException = (Exception)e.ExceptionObject;
                   currentException != null;
                   currentException = currentException.InnerException)
            {
                message.AppendFormat("\r\n\r\ntype={0}\r\n\r\nmessage={1}\r\n\r\nstack=\r\n{2}\r\n\r\n",
                                     currentException.GetType().FullName,
                                     currentException.Message,
                                     currentException.StackTrace);
            }

            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message.ToString(), EventLogEntryType.Error);
            }
        }
    }
}