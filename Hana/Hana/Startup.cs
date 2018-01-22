using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hana.Startup))]
namespace Hana
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
