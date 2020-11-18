using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VenturaHR.Web.Startup))]
namespace VenturaHR.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
