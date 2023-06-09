using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarocTARL.Startup))]
namespace MarocTARL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
