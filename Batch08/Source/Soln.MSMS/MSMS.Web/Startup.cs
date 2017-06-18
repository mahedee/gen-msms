using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSMS.Web.Startup))]
namespace MSMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
