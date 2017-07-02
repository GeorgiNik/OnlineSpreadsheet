using LibertyGlobalBP.Web.Application;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace LibertyGlobalBP.Web.Application
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            this.ConfigureHangfire(app);
        }
    }
}
