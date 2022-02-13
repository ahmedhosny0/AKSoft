using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AOne.Startup))]
namespace AOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
