using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Job.WebMvc.Startup))]
namespace Job.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
