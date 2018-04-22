using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ePower.Portal.Startup))]
namespace ePower.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
