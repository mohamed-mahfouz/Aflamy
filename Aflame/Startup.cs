using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aflame.Startup))]
namespace Aflame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
