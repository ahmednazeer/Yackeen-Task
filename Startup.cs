using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yackeen.Startup))]
namespace Yackeen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
