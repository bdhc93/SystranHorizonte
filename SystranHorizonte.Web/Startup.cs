using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystranHorizonte.Web.Startup))]
namespace SystranHorizonte.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
