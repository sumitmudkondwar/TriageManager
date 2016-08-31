using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TriageManager.Startup))]
namespace TriageManager
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
