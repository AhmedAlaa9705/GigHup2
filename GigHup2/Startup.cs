using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigHup2.Startup))]
namespace GigHup2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
