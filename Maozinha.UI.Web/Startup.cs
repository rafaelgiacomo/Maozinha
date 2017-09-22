using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Maozinha.UI.Web.Startup))]
namespace Maozinha.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
