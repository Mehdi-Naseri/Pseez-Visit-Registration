using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pseez.VisitRegistration.Startup))]
namespace Pseez.VisitRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
