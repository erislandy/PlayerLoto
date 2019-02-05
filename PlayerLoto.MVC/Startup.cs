using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayerLoto.MVC.Startup))]
namespace PlayerLoto.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
