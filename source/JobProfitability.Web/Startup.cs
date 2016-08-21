using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobManagement.WebMvc.Startup))]
namespace JobManagement.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
