using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Default Page_Load");
        }
        protected void btnUnhandled_Click1(object sender, EventArgs e)
        {
            // Queue the task.
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));

            // The Sleep gives the background thread time to run
            Thread.Sleep(1000);
        }

        // This thread procedure performs the task.
        static void ThreadProc(Object stateInfo)
        {
            Thread sendApplicantMail = new Thread(delegate ()
            {
                try
                {
                    try
                    {
                        throw (new Exception("ERROR Test Unhandled exception 1"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    throw (new Exception("ERROR Test Unhandled exception 2"));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
            sendApplicantMail.Start();
        }
    }
}