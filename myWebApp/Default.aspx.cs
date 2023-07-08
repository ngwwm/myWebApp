using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hangfire;
using myLogger;

namespace myWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Default Page_Load");

            if (User.Identity.IsAuthenticated)
            {
                Debug.WriteLine($"User is authenicated - {User.Identity.Name}");
            }
        }
        protected void btnUnhandled_Click(object sender, EventArgs e)
        {
            // Queue the task.
            //ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));

            // The Sleep gives the background thread time to run
            //Thread.Sleep(1000);
            //This try catch block will not be able to catch any unhandled exception inside a thread.
            try
            {
                ThreadProcUnhandledException(null);
            } catch (Exception ex)
            {
                myLog.mlog.Error(ex.Message);
                myLog.mlog.Error(ex.StackTrace);
            }
        }

        protected void btnHandled_Click(object sender, EventArgs e)
        {
            ThreadProc(null);
        }
        static void ThreadProcUnhandledException(Object stateInfo)
        {
            myLog.mlog.Info("ThreadProcUnhandledException() Start.");
            try
            {
                Thread sendApplicantMail = new Thread(delegate ()
                {
                    myLog.mlog.Info("ThreadProcUnhandledException() Thread sendApplicantMail Start.");
                    // try to open a non-exits file
                    // Open the text file using a stream reader.
                    using (var sr = new StreamReader("c:\\Temp\\NoSuchFile.txt"))
                    {
                        // Read the stream as a string, and write the string to the console.
                        Console.WriteLine(sr.ReadToEnd());
                    }
                    myLog.mlog.Info("ThreadProcUnhandledException() Thread sendApplicantMail End.");
                });

                myLog.mlog.Info("ThreadProcUnhandledException() Start Thread.");
                sendApplicantMail.Start();
                myLog.mlog.Info("ThreadProcUnhandledException() End Thread.");
            } catch (Exception ex)
            {
                myLog.mlog.Error(ex.Message);
                myLog.mlog.Error(ex.StackTrace);
            }
            myLog.mlog.Info("ThreadProcUnhandledException() End.");
        }

        static void ThreadProc(Object stateInfo)
        {
            myLog.mlog.Info("ThreadProc() Start.");
            try
            {
                Thread sendApplicantMail = new Thread(delegate ()
                {
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Start.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Wait for 5 seconds Start.");
                    Thread.Sleep(5000);
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail Doing Something after Wait for 5 seconds End.");
                    // try to open a non-exits file
                    try
                    {
                        // Open the text file using a stream reader.
                        using (var sr = new StreamReader("c:\\Temp\\NoSuchFile.txt"))
                        {
                            // Read the stream as a string, and write the string to the console.
                            Console.WriteLine(sr.ReadToEnd());
                        }
                    }
                    catch (Exception ex)
                    {
                        myLog.mlog.Error(ex.Message);
                        myLog.mlog.Error(ex.StackTrace);
                    }
                    finally
                    {
                        myLog.mlog.Info("ThreadProc() Start Thread - sendApplicantMail End.");
                    }
                });

                sendApplicantMail.Start();

                myLog.mlog.Info("ThreadProc() - Wait for 2 seconds Start"); 
                Thread.Sleep(2000);
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 
                myLog.mlog.Info("ThreadProc() - Doing something after Wait for 2 seconds End"); 

            }
            catch (Exception ex)
            {
                myLog.mlog.Error(ex.Message);
            }
            myLog.mlog.Info("ThreadProc End.");
        }

        protected void btnWebhook_Click(object sender, EventArgs e)
        {
            var webhookUrl = txtWebhookURL.Text;

            Webhook.SayHiAsync(webhookUrl, "Online");

            var jobId1 = BackgroundJob.Enqueue("webhook",
                () => Webhook.SayHiAsync(webhookUrl, "Hangfire:Queue:webhook"));
            var jobId2 = BackgroundJob.Enqueue(() => Webhook.SayHiAsync(webhookUrl, "Hangfire_2"));
        }
    }
}