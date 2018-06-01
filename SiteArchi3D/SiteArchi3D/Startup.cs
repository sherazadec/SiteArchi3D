using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteArchi3D.Startup))]
namespace SiteArchi3D
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
