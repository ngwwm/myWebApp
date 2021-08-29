using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Web;
using Microsoft.Extensions.Configuration;
using myWebApp.BusinessLayer;
using myWebApp.DataAccessLayer.Sales;
using myWebApp.DataLayer;

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
            var config = new ConfigurationBuilder();
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
            builder.RegisterType<MSSQLDatabase>().As<IDatabase>();
            //builder.RegisterType<Action<MSSQLDatabase>>().As<IDatabase>();

            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}