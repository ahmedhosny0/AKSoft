using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AKSoft.Startup))]
namespace AKSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
