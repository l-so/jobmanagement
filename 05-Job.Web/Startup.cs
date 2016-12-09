using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_05_Job.Web.Startup))]
namespace _05_Job.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
