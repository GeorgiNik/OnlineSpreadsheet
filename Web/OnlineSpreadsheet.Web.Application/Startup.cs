using OnlineSpreadsheet.Web.Application;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace OnlineSpreadsheet.Web.Application
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            //this.ConfigureHangfire(app);
        }
    }
}
