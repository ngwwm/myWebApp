using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Web;
using myWebApp.BusinessLayer;
using myWebApp.DataAccessLayer.Sales;
using myWebApp.DataAccessLayer.StackOverflow;
using myWebApp.DataAccessLayer.SubDomains;
using myWebApp.DataLayer;
using StackExchange.Redis;

namespace myWebApp
{

    public class Global : HttpApplication, IContainerProviderAccessor
    {

        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Add the configuration to the ConfigurationBuilder.
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            // config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
            // config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
            //config.AddJsonFile("autofac.json");

            // Register the ConfigurationModule with Autofac.
 /*
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
*/


            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();
            builder.RegisterType<SalesPersonBO>().As<ISalesPersonBO>();
            builder.RegisterType<SalesPersonDO>().As<ISalesPersonDO>();
            builder.RegisterType<SubDomainBO>().As<ISubDomainBO>();
            builder.RegisterType<SubDomainDO>().As<ISubDomainDO>();
            builder.RegisterType<UserBO>().As<IUserBO>();
            builder.RegisterType<UserDO>().As<IUserDO>();
            builder.RegisterType<MSSQLDatabase>().As<DataLayer.IRDBMSDatabase>();
            builder.RegisterType<MSSQLDatabase>().As<DataLayer.IRDBMSDatabase>();
            //builder.RegisterType<Action<MSSQLDatabase>>().As<IDatabase>();

            var cacheConnStr = ConfigurationManager.AppSettings["CacheConnectionString"];

            /*
            builder.Register<IConnectionMultiplexer>(c =>
                ConnectionMultiplexer.Connect(cacheConnStr)).SingleInstance();
            */

            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //log4net.Config.XmlConfigurator.Configure();
        }
    }
}