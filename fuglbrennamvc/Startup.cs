using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FuglBrennaMvc.Startup))]
namespace FuglBrennaMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
