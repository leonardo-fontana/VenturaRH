using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VenturaRH.Startup))]
namespace VenturaRH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
