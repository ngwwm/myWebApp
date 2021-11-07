using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using myWebApp.BusinessLayer;
using myWebApp.DataLayer;
using System.Diagnostics;
using System.Configuration;
using myWebApp.Model;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Redis;
using myLogger;
using System.Web.SessionState;

namespace myWebApp.Pages
{
    public partial class InheritSample : System.Web.UI.Page
    {

        public IRDBMSDatabase _database { get; set; }
        public ISalesPersonBO _salesPersonBO { get; set; }
        public IConnectionMultiplexer _redisConn { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            myLog.mlog.Info("InheritSample Page_Load.");

            var guid = Guid.NewGuid();

            if (HttpContext.Current.Session["Guid"] == null) 
            {
                /*
                SessionIDManager manager = new SessionIDManager();
                string newSessionId = manager.CreateSessionID(HttpContext.Current);
                bool isRedir = false;
                bool isAdded = false;
                HttpContext.Current.Session["guid"] = guid;
                manager.SaveSessionID(HttpContext.Current, newSessionId, out isRedir, out isAdded);
                myLog.mlog.Debug($"InheritSample Session New/Expired - new sessionId: {newSessionId}");
                */
                HttpContext.Current.Session["Guid"] = guid;
                myLog.mlog.Info($"InheritSample Session New/Expired - Guid: {guid}");
            }
            else
            {
                myLog.mlog.Info($"InheritSample Session Exists - Guid: {guid}");
            }
            //ASP.NET Server Controls - https://docs.microsoft.com/en-us/troubleshoot/aspnet/server-controls
            Label1.Text = "(Precompiled): Page_Load fired!";
            Label1.Text += ToString();
            Label1.Text += Request.UserAgent;
            //Label1.Text += _database.GetVersion();
            //https://developers.google.com/identity/protocols/oauth2/web-server#httprest
            var GoogleAuthUrl = "https://accounts.google.com/o/oauth2/v2/auth?scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/calendar&redirect_uri=http://localhost:52353/Pages/InheritSample.aspx&response_type=code&client_id=439132826761-v3kv4s8gcqj0dneaelrd9mtbderaitd2.apps.googleusercontent.com&access_type=offline&prompt=consent";

            MyHyperLink.NavigateUrl = GoogleAuthUrl;

            CreateAssembly();

            ListSalesPersons();
            var code = HttpContext.Current.Request.QueryString.Get("code");
            //MyWebAppGoogleCalendarIntegration();
        }

        private void ListSalesPersons()
        {
            //SalesPersonBO objBO = new SalesPersonBO();

            if (_salesPersonBO != null)
            {
                var data = _salesPersonBO.GetSalesPersonData();
                if (data is null)
                {
                    Debug.WriteLine("Oops");
                }
                else
                {
                    Debug.WriteLine(data.Count());
                    Label1.Text += $"\nThere are {data.Count()} records in xxx table.";
                    GridViewSalesPerson.DataSource = data;
                    GridViewSalesPerson.DataBind();
                }
            }
            var token = HttpContext.Current.Request.QueryString.Get("token");
            lblSessionId.Text = HttpContext.Current.Session.SessionID;
            lblGuid.Text = HttpContext.Current.Session["Guid"].ToString();
            lblServiceID.Text = ConfigurationManager.AppSettings["ServiceID"];
        }

        public List<SalesPerson> GetSalesPerson()
        {
            return _salesPersonBO.GetSalesPersonData();
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //_database.Disconnect();
            Debug.WriteLine("UnLoad");
        }

        private string fname = "Martin";
        private string lname = "NG";

        public override string ToString() => $"{fname} {lname}".Trim();

        private void CreateAssembly()
        {
            /*
            try
            {
                object db = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType("myWebApp.DataLayer.IDatabase)"));
            }
            */
        }


        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarEvents, CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        static void MyWebAppGoogleCalendarIntegration() 
        {
            string AppPath = System.Web.HttpRuntime.AppDomainAppPath;
            UserCredential credential;

            using (var stream =
                    new FileStream(AppPath + "\\credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = AppPath + "\\token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)
                        ).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                    foreach (var eventItem in events.Items)
                    {
                        string when = eventItem.Start.DateTime.ToString();
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                        }
                        Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                    }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.Read();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //MyWebAppGoogleCalendarIntegration();
            IDatabase db = _redisConn.GetDatabase();
            string value = "xxxxxxx";
            db.StringSet("foo", value);
            
            value = db.StringGet("foo");
            Debug.WriteLine(value); // writes: "abcdefg"
        }
    }
}