using Owin;
using Maozinha.UI.Web.Models;

namespace Maozinha.UI.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
        }
    }
}