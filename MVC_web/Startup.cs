using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_web.Startup))]
namespace MVC_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
