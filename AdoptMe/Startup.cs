using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdoptMe.Startup))]
namespace AdoptMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
