using System;
using Hangfire;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HangFireDemo.Startup))]

namespace HangFireDemo
{
    public class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        //    app.UseHangfireServer();
        //}

        //public void Configuration(IAppBuilder app)
        //{
        //    GlobalConfiguration.Configuration.UseSqlServerStorage("HangFireEntity");

        //    app.UseHangfireDashboard();
        //    app.UseHangfireServer();
        //}
    }
}
