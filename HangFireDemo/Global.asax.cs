using Hangfire.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HangFireDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private Hangfire.BackgroundJobServer _backgroundJobServer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var storage = new SqlServerStorage(System.Configuration.ConfigurationManager.ConnectionStrings["HangFireEntity"].ConnectionString); // here HangFireEntity is Connection string of the HangFire DB which is in Sql Server , it is in web.config file under the connection string section
            var options = new Hangfire.BackgroundJobServerOptions();

            var _backgroundJobServer = new Hangfire.BackgroundJobServer(options, storage);
            //_backgroundJobServer.Start();
            Hangfire.JobStorage.Current = storage;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _backgroundJobServer.Dispose();
        }
    }
}